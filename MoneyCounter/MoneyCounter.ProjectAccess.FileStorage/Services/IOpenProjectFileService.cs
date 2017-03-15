﻿namespace MoneyCounter.ProjectAccess.FileStorage.Services
{
	/// <summary>
	/// Интерфейс загрузки файла.
	/// </summary>
	public interface IOpenProjectFileService
	{
		/// <summary>
		/// Открывает дилог выбора файла.
		/// </summary>
		/// <param name="path">Возвращает путь к файлу.</param>
		/// <returns>Истина - пользовавтель выбрал файл. Ложь - отмена выбора.</returns>
		bool? OpenProjectFile(out string path);
	}
}
