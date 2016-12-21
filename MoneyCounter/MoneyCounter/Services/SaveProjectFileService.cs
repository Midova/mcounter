using Microsoft.Win32;

namespace MoneyCounter.Services
{
	/// <summary>
	/// Сервис сохранения в файл.
	/// </summary>
	public class SaveProjectFileService : ISaveProjectFileService
	{
		/// <summary>
		/// Открывает дилог выбора файла.
		/// </summary>
		/// <param name="path">Возвращает путь к файлу</param>
		/// <returns>Истина - пользовавтель выбрал файл. Ложь - отмена выбора.</returns>
		public bool? SaveProjectFile(out string path)
		{
			var dialog = new SaveFileDialog()
			{
				DefaultExt = Session.FileExtension
			};

			var result = dialog.ShowDialog();
			path = dialog.FileName;

			return result;
		}
	}
}
