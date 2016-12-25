using Microsoft.Win32;

namespace MoneyCounter.Services
{
	/// <summary>
	/// Сервис сохранения в файл.
	/// </summary>
	public class SaveProjectFileService : ISaveProjectFileService
	{
		/// <inheritdoc />
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
