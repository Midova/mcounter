using Catel.MVVM;
using MoneyCounter.Services;
using System.Windows.Input;
using Catel.Data;
using MoneyCounter.Infrastructure.Session;
using MoneyCounter.Data.Model;

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

			_ProjectManager = new ProjectManager(_ConfirmationRequestService, _FileOpenDialogService, _FileSaveDialogService);

			OpenProjectCommand = new Command(_ProjectManager.LoadProject);
			SaveProjectCommand = new Command(_ProjectManager.SaveProject, _ProjectManager.CanSaveProject);
			SaveAsProjectCommand = new Command(_ProjectManager.SaveAsProject);

			CloseProjectCommand = new Command(_ProjectManager.CloseProject, _ProjectManager.CanCloseProject);
			CreateNewProjectCommand = new Command(_ProjectManager.CreateNewProject);
					
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
		/// Сервис выбора пути к файлу проекта.
		/// </summary>
		private IOpenProjectFileService _FileOpenDialogService;

		/// <summary>
		/// Сервис для выбора файла сохранения проекта.
		/// </summary>
		private ISaveProjectFileService _FileSaveDialogService;

		/// <summary>
		/// Сервис работы с окном сообщений.
		/// </summary>
		private IConfirmationRequestService _ConfirmationRequestService;

		#endregion

		#region Project Management

		/// <summary>
		/// Менеджер сессии.
		/// </summary>
		private ProjectManager _ProjectManager;

		/// <summary>
		/// Текущая загруженная сессия.
		/// </summary>
		public Project Project => _ProjectManager.Project;

		/// <summary>
		/// Получает команду создания нового проекта.
		/// </summary>
		public ICommand CreateNewProjectCommand { get; private set; }

		/// <summary>
		/// Получает команду загрузки проекта из файла.
		/// </summary>
		public ICommand OpenProjectCommand { get; private set; }

		/// <summary>
		/// Получает команду сохранения проекта в файл.
		/// </summary>
		public ICommand SaveProjectCommand { get; private set; }

		/// <summary>
		/// Получает команду сохранения проекта в файл по новому адресу.
		/// </summary>
		public ICommand SaveAsProjectCommand { get; private set; }

		/// <summary>
		/// Получает команду закрытия проекта.
		/// </summary>
		public ICommand CloseProjectCommand { get; private set; }

		#endregion
	}
}
