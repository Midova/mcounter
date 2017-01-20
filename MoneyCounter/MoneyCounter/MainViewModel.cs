﻿using Catel.MVVM;
using MoneyCounter.Services;
using System.Windows.Input;
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

			SessionManager = new SessionManager(Project, _ConfirmationRequestService, _FileOpenDialogService, _FileSaveDialogService);

			LoadProjectCommand = new Command(SessionManager.LoadProject);
			SaveProjectCommand = new Command(SessionManager.SaveProject, SessionManager.CanSaveProject);
			SaveAsProjectCommand = new Command(SessionManager.SaveAsProject);

			CloseProjectCommand = new Command(SessionManager.CloseProject, SessionManager.CanCloseProject);
			CreateNewProjectCommand = new Command(SessionManager.CreateNewProject);
					
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
		public SessionManager SessionManager { get; }

		/// <summary>
		/// Текущий загруженный проект.
		/// </summary>
		public Project Project { get; private set; }

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
