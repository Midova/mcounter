using MoneyCounter.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MoneyCounter
{
	/// <summary>
	/// Логика взаимодействия для App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			var mainWindow = new MainWindow();

			var openFileService = new OpenProjectFileService();
			var saveFileService = new SaveProjectFileService();
			var confirmationRequestService = new ConfirmationRequestService();

			var context = new MainViewModel(openFileService, saveFileService, confirmationRequestService);

			mainWindow.DataContext = context;
						
			MainWindow = mainWindow;
			MainWindow.Show();
		}
	}
}
