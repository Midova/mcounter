using Microsoft.Win32;
using MoneyCounter.Session;

namespace MoneyCounter.Services
{
	/// <summary>
	/// Сервис загрузки из файла.
	/// </summary>
	public class OpenProjectFileService : IOpenProjectFileService
	{
		/// <inheritdoc />
		public bool? OpenProjectFile(out string path)
		{
			var dialog = new OpenFileDialog()
			{				
				Multiselect = false,
				DefaultExt = Project.FileExtension,
				Filter = "Budget file|*.mcounter"
			};

			var result = dialog.ShowDialog();
			path = dialog.FileName;

			return result;
		}
	}
}
