using System.Windows;

namespace MoneyCounter.Services
{
	/// <summary>
	/// Интерфейс работы с окном сообщений.
	/// </summary>
	public interface IConfirmationRequestService
	{
		/// <summary>
		/// Вывает окно сообщения.
		/// </summary>
		/// <param name="text">Текст сообщеня.</param>
		/// <param name="caption">Заголовок сообщения.</param>
		/// <param name="buttons">Кнопки сообщения.</param>
		/// <param name="image">Знак сообщения.</param>
		/// <returns>Резльта выбора пользователя.</returns>
		MessageBoxResult RequestConfirmation(string text, string caption, MessageBoxButton buttons, MessageBoxImage image);
	}
}
