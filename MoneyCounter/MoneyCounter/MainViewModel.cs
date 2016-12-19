using Catel.MVVM;
using MoneyCounter.Services;
using System.Windows.Input;

namespace MoneyCounter
{
	public class MainViewModel
	{		
		public MainViewModel(IOpenProjectFileService fileOpenDialogService,
			ISaveProjectFileService fileSaveDialogService)
		{
			_FileOpenDialogService = fileOpenDialogService;
			_FileSaveDialogService = fileSaveDialogService;

			LoadSessionCommand = new Command(LoadSession);
			SaveSessionCommand = new Command(SaveSession);
			SaveAsSessionCommand = new Command(SaveAsSession);
		}

		/// <summary>
		/// Сервис загрузки данных из файла.
		/// </summary>
		private IOpenProjectFileService _FileOpenDialogService;

		/// <summary>
		/// Сервис сохранения данных в файл.
		/// </summary>
		private ISaveProjectFileService _FileSaveDialogService;

		/// <summary>
		/// Текущая загруженная сессия.
		/// </summary>
		public Session Session { get; private set; }


		/// <summary>
		/// Получает обработчик загрузки проекта из файла.
		/// </summary>
		public ICommand LoadSessionCommand { get; private set; }

		/// <summary>
		/// Загрузка проекта из файла.
		/// </summary>
		private void LoadSession()
		{

		}

		/// <summary>
		/// Получает обработчик сохранения проекта в файл.
		/// </summary>
		public ICommand SaveSessionCommand { get; private set; }

		/// <summary>
		/// Сохранение проекта в файл.
		/// </summary>
		private void SaveSession()
		{

		}

		/// <summary>
		/// Получает обработчик сохранения проекта в файл по новому адресу.
		/// </summary>
		public ICommand SaveAsSessionCommand { get; private set; }

		/// <summary>
		/// Cохранение проекта в файл по новому адресу.
		/// </summary>
		private void SaveAsSession()
		{

		}

		/// <summary>
		/// Получает обработчик закрытия сессии.
		/// </summary>
		public ICommand ClosingSessionCommand { get; private set; }

		private void ClosingSession()
		{

		}
	}
}
