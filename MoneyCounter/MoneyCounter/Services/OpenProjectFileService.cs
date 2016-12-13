using Microsoft.Win32;

namespace MoneyCounter.Services
{
	public class OpenProjectFileService : IOpenProjectFileService
	{
		public bool? OpenProjectFile(out string path)
		{
			var dialog = new OpenFileDialog()
			{				
				Multiselect = false,
				DefaultExt = ".budget",
				Filter = "Budget file|*.budget"
			};

			var result = dialog.ShowDialog();
			path = dialog.FileName;

			return result;
		}
	}
}
