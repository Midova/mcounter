using Catel.MVVM;
using MoneyCounter.Services;
using System.IO;
using System.Windows.Input;
using System;
using Catel.Data;

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
			Session = new Session();

			LoadSessionCommand = new Command(LoadSession);
			SaveSessionCommand = new Command(SaveSession, ChangedSession);
			SaveAsSessionCommand = new Command(SaveAsSession);

			CloseSessionCommand = new Command(CloseSession, CanCloseSession);
			CreationNewSessionCommand = new Command(CreationNewSession);
					
			PropertyChanged += MainViewModel_PropertyChanged;		
		}

		/// <summary>
		/// Изменение свойств модели главного окна.
		/// </summary>
		/// <param name="sender">Измененное свойство.</param>
		/// <param name="e">Данные для события.</param>
		private void MainViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			((Command)CloseSessionCommand).RaiseCanExecuteChanged();
			((Command)SaveAsSessionCommand).RaiseCanExecuteChanged();
			((Command)SaveSessionCommand).RaiseCanExecuteChanged();
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
		public Session Session { get; private set; }

		/// <summary>
		/// Получает обработчик создания новой сессии.
		/// </summary>
		public ICommand CreationNewSessionCommand { get; private set; }

		/// <summary>
		/// Cозданиe новой сессии.
		/// </summary>
		private void CreationNewSession()
		{
			if (Session != null)
				CloseSession();
			
			var newSession = new Session();
			 
		}  

		/// <summary>
		/// Получает обработчик загрузки проекта из файла.
		/// </summary>
		public ICommand LoadSessionCommand { get; private set; }

		/// <summary>
		/// Загрузка проекта из файла.
		/// </summary>
		private void LoadSession()
		{
			CloseSession();

			string path;
			var result = _FileOpenDialogService.OpenProjectFile(out path);

			if (result != true)
				return;

			Session = Session.Load(path);

			Session.FilePath = path;
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
			if (Session.FilePath != string.Empty)
				Session.Save(Session.FilePath, Session);
			else
				SaveAsSession();
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
			string path;
			var result = _FileSaveDialogService.SaveProjectFile(out path);

			if (result != true)
				return;

			Session.Save(path, Session);
		}

		/// <summary>
		/// Получает обработчик закрытия сессии.
		/// </summary>
		public ICommand CloseSessionCommand { get; private set; }

		/// <summary>
		/// Закрытие сессии, с сохранением или без.
		/// </summary>
		private void CloseSession()
		{
			if (!Session.IsDerty)
				return;

			var result = _ConfirmationRequestService
				.RequestConfirmation("Сессия не сохранена. Сохранить?", "Внимание", System.Windows.MessageBoxButton.OKCancel, System.Windows.MessageBoxImage.Warning);


			if (result != System.Windows.MessageBoxResult.OK)
				return;

			SaveSession(); 
						
		}

		/// <summary>
		/// Загружалась ли сессия.
		/// </summary>
		/// <returns>Правда- если сессия заполнена, ложь- иначе.</returns>
		private bool CanCloseSession() => Session != null;

		/// <summary>
		/// Изменялась ли сессия.
		/// </summary>
		/// <returns>Правда- сессия менялась, ложь - иначе.</returns>
		private bool ChangedSession() => Session.IsDerty == true;
			
	}
}
