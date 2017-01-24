using Catel.MVVM;
using MoneyCounter.Services;
using System.Windows.Input;
using Catel.Data;
using MoneyCounter.Infrastructure.Session;

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

			ProjectManager = new ProjectManager(_ConfirmationRequestService, _FileOpenDialogService, _FileSaveDialogService);

			LoadProjectCommand = new Command(ProjectManager.LoadProject);
			SaveProjectCommand = new Command(ProjectManager.SaveProject, ProjectManager.CanSaveProject);
			SaveAsProjectCommand = new Command(ProjectManager.SaveAsProject);

			CloseProjectCommand = new Command(ProjectManager.CloseProject, ProjectManager.CanCloseProject);
			CreateNewProjectCommand = new Command(ProjectManager.CreateNewProject);
					
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

		/// <summary>
		/// Менеджер сессии.
		/// </summary>
		public ProjectManager ProjectManager { get; }

		/// <summary>
		/// Получает обработчик создания нового проекта.
		/// </summary>
		public ICommand CreateNewProjectCommand { get; private set; }

		/// <summary>
		/// Получает обработчик загрузки проекта из файла.
		/// </summary>
		public ICommand LoadProjectCommand { get; private set; }

		/// <summary>
		/// Получает обработчик сохранения проекта в файл.
		/// </summary>
		public ICommand SaveProjectCommand { get; private set; }

		/// <summary>
		/// Получает обработчик сохранения проекта в файл по новому адресу.
		/// </summary>
		public ICommand SaveAsProjectCommand { get; private set; }

		/// <summary>
		/// Получает обработчик закрытия проекта.
		/// </summary>
		public ICommand CloseProjectCommand { get; private set; }
	}
}
