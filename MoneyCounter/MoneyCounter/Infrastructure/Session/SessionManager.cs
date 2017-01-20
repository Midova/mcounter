using MoneyCounter.Services;

namespace MoneyCounter.Infrastructure.Session
{
	/// <summary>
	/// Класс управления проектом.
	/// </summary>
	public class SessionManager : ISessionManager
	{		
		public SessionManager(IConfirmationRequestService confirmationRequestService, IOpenProjectFileService fileOpenDialogService, ISaveProjectFileService fileSaveDialogService)
		{
			Project = new Project();
			_ConfirmationRequestService = confirmationRequestService;
			_FileOpenDialogService = fileOpenDialogService;
			_FileSaveDialogService = fileSaveDialogService;
		}

		/// <summary>
		/// Сервис работы с окном сообщений.
		/// </summary>
		private IConfirmationRequestService _ConfirmationRequestService;

		/// <summary>
		/// Сервис выбора пути к файлу проекта.
		/// </summary>
		private IOpenProjectFileService _FileOpenDialogService;

		/// <summary>
		/// Сервис для выбора файла сохранения проекта.
		/// </summary>
		private ISaveProjectFileService _FileSaveDialogService;

		/// <inheritdoc />
		public Project Project { get; private set; }

		/// <inheritdoc />
		public bool CanCloseProject() => Project != null;

		/// <inheritdoc />
		public bool CanSaveProject() => Project.IsDerty == true;

		/// <inheritdoc />
		public void CloseProject()
		{
			if (!Project.IsDerty)
				return;

			var result = _ConfirmationRequestService
				.RequestConfirmation("Сессия не сохранена. Сохранить?", "Внимание", System.Windows.MessageBoxButton.OKCancel, System.Windows.MessageBoxImage.Warning);

			if (result != System.Windows.MessageBoxResult.OK)
				return;

			SaveProject();
		}

		/// <inheritdoc />
		public void CreateNewProject()
		{
			if (Project != null)
				CloseProject();

			var newProject = new Project();
		}

		/// <inheritdoc />		
		public void LoadProject()
		{
			CloseProject();

			string path;
			var result = _FileOpenDialogService.OpenProjectFile(out path);

			if (result != true)
				return;

			Project = Project.Load(path);
			Project.FilePath = path;
		}

		/// <inheritdoc />
		public void SaveAsProject()
		{
			string path;
			var result = _FileSaveDialogService.SaveProjectFile(out path);

			if (result != true)
				return;

			Project.Save(path, Project);
		}

		/// <inheritdoc />
		public void SaveProject()
		{
			if (Project.FilePath != string.Empty)
				Project.Save(Project.FilePath, Project);
			else
				SaveAsProject();
		}
	}
}
