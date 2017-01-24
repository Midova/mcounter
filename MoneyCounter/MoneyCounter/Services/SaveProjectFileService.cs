using Microsoft.Win32;
using MoneyCounter.Infrastructure.Session;

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
				DefaultExt = ProjectManager.FileExtension,
				Filter = "Budget file|*.mcounter"
			};

			var result = dialog.ShowDialog();
			path = dialog.FileName;

			return result;
		}
	}
}
