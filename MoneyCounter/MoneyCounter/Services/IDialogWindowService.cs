using System;

namespace MoneyCounter.Services
{
	/// <summary>
	/// Интерфейс работы с диалоговым окном.
	/// </summary>
	public interface IDialogWindowService
	{
		/// <summary>
		/// Добавление связи в словарь.
		/// </summary>
		/// <param name="viewModel">Модель представления данных.</param>
		/// <param name="window">Окно.</param>
		void Register(Type viewModel, Type window);

		/// <summary>
		/// Показывает окно дилога с указанным контектом.
		/// </summary>
		/// <param name="viewModelValue">Модель представления ипспользуемая в качестве контекста данных для диалогового окна.</param>
		void ShowDialog(object viewModelValue);
	}
}
