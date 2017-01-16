using Catel.MVVM;
using MoneyCounter.Services;
using System.IO;
using System.Windows.Input;
using System;
using Catel.Data;
using MoneyCounter.Session;

namespace MoneyCounter
{
	/// <summary>
	/// Класс, работы с главным окном.
	/// </summary>
	public class MainViewModel : ObservableObject
	{		
		public MainViewModel(IOpenProjectFileService fileOpenDialogService,
			ISaveProjectFileService fileSaveDialogService, IConfirmationRequestService confirmationRequestService)
		{
			_FileOpenDialogService = fileOpenDialogService;
			_FileSaveDialogService = fileSaveDialogService;
			_ConfirmationRequestService = confirmationRequestService;
			Project = new Project();

			LoadProjectCommand = new Command(LoadProject);
			SaveProjectCommand = new Command(SaveProject, CanSaveProject);
			SaveAsProjectCommand = new Command(SaveAsProject);

			CloseProjectCommand = new Command(CloseProject, CanCloseProject);
			CreateNewProjectCommand = new Command(CreateNewProject);
					
			PropertyChanged += MainViewModel_PropertyChanged;		
		}

		/// <summary>
		/// Изменение свойств модели главного окна.
		/// </summary>
		/// <param name="sender">Измененное свойство.</param>
		/// <param name="e">Данные для события.</param>
		private void MainViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			((Command)CloseProjectCommand).RaiseCanExecuteChanged();
			((Command)SaveAsProjectCommand).RaiseCanExecuteChanged();
			((Command)SaveProjectCommand).RaiseCanExecuteChanged();
		}

		#region Infrastructure

		/// <summary>
		/// Сервис загрузки данных из файла.
		/// </summary>
		private IOpenProjectFileService _FileOpenDialogService;

		/// <summary>
		/// Сервис сохранения данных в файл.
		/// </summary>
		private ISaveProjectFileService _FileSaveDialogService;

		/// <summary>
		/// Сервис работы с окном сообщений.
		/// </summary>
		private IConfirmationRequestService _ConfirmationRequestService;
		#endregion

		/// <summary>
		/// Текущая загруженная сессия.
		/// </summary>
		public Project Project { get; private set; }

		/// <summary>
		/// Получает обработчик создания нового проекта.
		/// </summary>
		public ICommand CreateNewProjectCommand { get; private set; }

		/// <summary>
		/// Cозданиe новой сессии.
		/// </summary>
		private void CreateNewProject()
		{
			if (Project != null)
				CloseProject();

			var newProject = new Project();
		}  

		/// <summary>
		/// Получает обработчик загрузки проекта из файла.
		/// </summary>
		public ICommand LoadProjectCommand { get; private set; }

		/// <summary>
		/// Загрузка проекта из файла.
		/// </summary>
		private void LoadProject()
		{
			CloseProject();

			string path;
			var result = _FileOpenDialogService.OpenProjectFile(out path);

			if (result != true)
				return;

			Project = Project.Load(path);
			Project.FilePath = path;
		}

		/// <summary>
		/// Получает обработчик сохранения проекта в файл.
		/// </summary>
		public ICommand SaveProjectCommand { get; private set; }

		/// <summary>
		/// Сохранение проекта в файл.
		/// </summary>
		private void SaveProject()
		{
			if (Project.FilePath != string.Empty)
				Project.Save(Project.FilePath, Project);
			else
				SaveAsProject();
		}

		/// <summary>
		/// Получает обработчик сохранения проекта в файл по новому адресу.
		/// </summary>
		public ICommand SaveAsProjectCommand { get; private set; }

		/// <summary>
		/// Cохранение проекта в файл по новому адресу.
		/// </summary>
		private void SaveAsProject()
		{
			string path;
			var result = _FileSaveDialogService.SaveProjectFile(out path);

			if (result != true)
				return;

			Project.Save(path, Project);
		}

		/// <summary>
		/// Получает обработчик закрытия проекта.
		/// </summary>
		public ICommand CloseProjectCommand { get; private set; }

		/// <summary>
		/// Закрытие проекта, с сохранением или без.
		/// </summary>
		private void CloseProject()
		{
			if (!Project.IsDerty)
				return;

			var result = _ConfirmationRequestService
				.RequestConfirmation("Сессия не сохранена. Сохранить?", "Внимание", System.Windows.MessageBoxButton.OKCancel, System.Windows.MessageBoxImage.Warning);
			
			if (result != System.Windows.MessageBoxResult.OK)
				return;

			SaveProject();						
		}

		/// <summary>
		/// Загружался ли проект.
		/// </summary>
		/// <returns>Правда- если сессия заполнена, ложь- иначе.</returns>
		private bool CanCloseProject() => Project != null;

		/// <summary>
		/// Изменялся ли проект.
		/// </summary>
		/// <returns>Правда- сессия менялась, ложь - иначе.</returns>
		private bool CanSaveProject() => Project.IsDerty == true;
			
	}
}
