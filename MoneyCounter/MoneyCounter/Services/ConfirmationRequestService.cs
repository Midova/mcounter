using System.Windows;

namespace MoneyCounter.Services
{
	/// <summary>
	/// Сервис работы с окном сообщений.
	/// </summary>
	public class ConfirmationRequestService : IConfirmationRequestService
	{
		/// <summary>
		/// Вывает окно сообщения.
		/// </summary>
		/// <param name="text">Текст сообщеня.</param>
		/// <param name="caption">Заголовок сообщения.</param>
		/// <param name="buttons"></param>
		/// <param name="image"></param>
		/// <returns>Резльта выбора пользователя.</returns>
		public MessageBoxResult RequestConfirmation(string text, string caption, MessageBoxButton buttons, MessageBoxImage image)
		{
			return MessageBox.Show(text, caption, buttons, image);
		}
				
	}
}
