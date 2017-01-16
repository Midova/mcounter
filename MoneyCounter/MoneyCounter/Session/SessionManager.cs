using MoneyCounter.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyCounter.Session
{
	class SessionManager : ISessionManager
	{
		private IConfirmationRequestService _ConfirmationRequestService;
		private IOpenProjectFileService _FileOpenDialogService;
		private ISaveProjectFileService _FileSaveDialogService;

		public SessionManager(Project project, IConfirmationRequestService confirmationRequestService, IOpenProjectFileService fileOpenDialogService, ISaveProjectFileService fileSaveDialogService)
		{
			Project = project;
			_ConfirmationRequestService = confirmationRequestService;
			_FileOpenDialogService = fileOpenDialogService;
			_FileSaveDialogService = fileSaveDialogService;
		}
		
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

			SaveProject(); throw new NotImplementedException();
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
			if (Project.FilePath != string.Empty)
				Project.Save(Project.FilePath, Project);
			else
				SaveAsProject();
		}

		/// <inheritdoc />
		public void SaveProject()
		{
			string path;
			var result = _FileSaveDialogService.SaveProjectFile(out path);

			if (result != true)
				return;

			Project.Save(path, Project);
		}
	}
}
