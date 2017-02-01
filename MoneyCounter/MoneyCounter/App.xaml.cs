using MoneyCounter.Services;
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

			//Написано для проверки перехода по гиперсылке из окна информации о программе.
			var aboutWindow = new AboutWindow();
			aboutWindow.Show();
		}
	}
}
