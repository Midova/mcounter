﻿using Catel.MVVM;
using MoneyCounter.Services;
using System.IO;
using System.Windows.Input;
using System;

namespace MoneyCounter
{
	public class MainViewModel
	{		
		public MainViewModel(IOpenProjectFileService fileOpenDialogService,
			ISaveProjectFileService fileSaveDialogService, IConfirmationRequestService confirmationRequestService)
		{
			_FileOpenDialogService = fileOpenDialogService;
			_FileSaveDialogService = fileSaveDialogService;
			_ConfirmationRequestService = confirmationRequestService;

			LoadSessionCommand = new Command(LoadSession);
			SaveSessionCommand = new Command(SaveSession);
			SaveAsSessionCommand = new Command(SaveAsSession);

			CloseSessionCommand = new Command(CloseSession, CanCloseSession);
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
		/// Сервис работы с окном сообщений.
		/// </summary>
		private IConfirmationRequestService _ConfirmationRequestService;

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
		public ICommand CloseSessionCommand { get; private set; }

		/// <summary>
		/// Закрытие сессии, с сохранением или без.
		/// </summary>
		private void CloseSession()
		{
			if (Session.IsDerty)
			{
				var result = _ConfirmationRequestService
					.RequestConfirmation("", "Внимание", System.Windows.MessageBoxButton.OKCancel, System.Windows.MessageBoxImage.Warning);

				if (result == System.Windows.MessageBoxResult.OK)
				{
					if (File.Exists(Session.FilePath))
					{
						var savePath = string.Empty;
						if (_FileSaveDialogService.SaveProjectFile(out savePath) ?? false)
							Session.FilePath = savePath;
						else
							return;
					}

					Session.Save(Session.FilePath, Session);
				}
			}
		}

		/// <summary>
		/// Загружалась ли сессия.
		/// </summary>
		/// <returns>Правда- если сессия заполнена, ложь- иначе.</returns>
		private bool CanCloseSession()
		{
			return Session != null;
		}

	}
}
