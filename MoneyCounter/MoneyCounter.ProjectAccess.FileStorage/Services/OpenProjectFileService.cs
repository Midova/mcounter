﻿using Microsoft.Win32;

namespace MoneyCounter.ProjectAccess.FileStorage.Services
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
				DefaultExt = ProjectManager.FileExtension,
				Filter = "Budget file|*.mcounter"
			};

			var result = dialog.ShowDialog();
			path = dialog.FileName;

			return result;
		}
	}
}
