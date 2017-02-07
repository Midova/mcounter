using System;

namespace MoneyCounter.Services
{
	/// <summary>
	/// Интерфейс работы с диалоговым окном
	/// </summary>
	public interface IDialogWindowService
	{
		/// <summary>
		/// Добавление связи в словарь
		/// </summary>
		/// <param name="viewModel">Модель представления данных</param>
		/// <param name="window">Окно</param>
		void Add(Type viewModel, Type window);

		/// <summary>
		/// Метод который заставляет окно показываться
		/// </summary>
		/// <param name="viewModelValue">Выбраная модель представление данных.</param>
		void ShowDialog(object viewModelValue);
	}
}
