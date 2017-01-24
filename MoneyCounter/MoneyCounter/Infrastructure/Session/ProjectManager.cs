using MoneyCounter.Infrastructure.ProjectAccess;
using MoneyCounter.Services;
using Newtonsoft.Json;
using System.IO;
using MoneyCounter.Data.Model;

namespace MoneyCounter.Infrastructure.Session
{
	/// <summary>
	/// Класс управления проектом.
	/// </summary>
	public class ProjectManager : IProjectManager
	{		
		public ProjectManager(IConfirmationRequestService confirmationRequestService, IOpenProjectFileService fileOpenDialogService, ISaveProjectFileService fileSaveDialogService)
		{
			Project = new Project();
			FilePath = string.Empty;
			_ConfirmationRequestService = confirmationRequestService;
			_FileOpenDialogService = fileOpenDialogService;
			_FileSaveDialogService = fileSaveDialogService;
		}

		/// <summary>
		/// Разрешение файла, для сохранения данного проекта.
		/// </summary>
		public const string FileExtension = ".mcounter";

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

		/// <summary>
		/// Получает или задает путь к файлу проекта.
		/// </summary>
		public string FilePath { get; set; }
		
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

			FilePath = path;
			var content = File.ReadAllText(FilePath);

			Project = JsonConvert.DeserializeObject<Project>(content);
		}

		/// <summary>
		/// Выполняет сериализацию проекта по указанному пути.
		/// </summary>
		/// <param name="filePath">Путь к файлу проекта.</param>
		/// <param name="project">Текущий проект.</param>
		public static void Save(string filePath, Project project)
		{
			JsonSerializer serializer = new JsonSerializer();

			using (StreamWriter sw = new StreamWriter(filePath))
			using (JsonWriter writer = new JsonTextWriter(sw))
			{
				serializer.Serialize(writer, project);
				writer.Close();
			}
		}

		/// <inheritdoc />
		public void SaveAsProject()
		{
			string path;
			var result = _FileSaveDialogService.SaveProjectFile(out path);

			if (result != true)
				return;

			Save(path, Project);
		}

		/// <inheritdoc />
		public void SaveProject()
		{
			if (FilePath != string.Empty)
				Save(FilePath, Project);
			else
				SaveAsProject();
		}
	}
}
