using System.Windows;

namespace MoneyCounter.Services
{
	/// <summary>
	/// Сервис работы с окном сообщений.
	/// </summary>
	public class ConfirmationRequestService : IConfirmationRequestService
	{
		/// <inheritdoc />
		public MessageBoxResult RequestConfirmation(string text, string caption, MessageBoxButton buttons, MessageBoxImage image)
		{
			return MessageBox.Show(text, caption, buttons, image);
		}
				
	}
}
