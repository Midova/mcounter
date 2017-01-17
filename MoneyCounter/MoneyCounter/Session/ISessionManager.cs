﻿namespace MoneyCounter.Session
{
	public interface ISessionManager
	{
		/// <summary>
		/// Текущий проект.
		/// </summary>
		Project Project { get; }

		/// <summary>
		/// Cозданиe новой сессии.
		/// </summary>
		void CreateNewProject();

		/// <summary>
		/// Загрузка проекта из файла.
		/// </summary>
		void LoadProject();

		/// <summary>
		/// Сохранение проекта в файл.
		/// </summary>
		void SaveProject();

		/// <summary>
		/// Cохранение проекта в файл по новому адресу.
		/// </summary>
		void SaveAsProject();

		/// <summary>
		/// Закрытие проекта, с сохранением или без.
		/// </summary>
		void CloseProject();

		/// <summary>
		/// Загружался ли проект.
		/// </summary>
		/// <returns>Правда- если сессия заполнена, ложь- иначе.</returns>
		bool CanCloseProject();

		/// <summary>
		/// Изменялся ли проект.
		/// </summary>
		/// <returns>Правда- сессия менялась, ложь - иначе.</returns>
		bool CanSaveProject();
	}
}
