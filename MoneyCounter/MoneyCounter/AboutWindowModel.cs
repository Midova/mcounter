using Catel.MVVM;
using System.Windows.Input;

namespace MoneyCounter
{
	/// <summary>
	/// Класс работы с окном информации о программе.
	/// </summary>
	public class AboutWindowModel
	{
		public AboutWindowModel()
		{
			GoToIconsSiteCommand = new Command(GoToIconsSite);
		}

		/// <summary>
		/// Получает обработчик открытия сайта с иконками.
		/// </summary>
		public ICommand GoToIconsSiteCommand { get; private set; }

		/// <summary>
		/// Переход на сайт с иконками.
		/// </summary>
		private void GoToIconsSite()
		{
			System.Diagnostics.Process.Start("https://ru.icons8.com/web-app");
		}

	}
}
