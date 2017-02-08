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
			OpenIconsSourceSiteCommand = new Command(OpenIconsSourceSite);
		}

		/// <summary>
		/// Получает команду открытия сайта с иконками.
		/// </summary>
		public ICommand OpenIconsSourceSiteCommand { get; private set; }

		/// <summary>
		/// Переход на сайт с иконками.
		/// </summary>
		private void OpenIconsSourceSite()
		{
			System.Diagnostics.Process.Start("https://ru.icons8.com/web-app");
		}

	}
}
