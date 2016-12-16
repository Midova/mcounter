using MoneyCounter.Data.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MoneyCounter
{
	/// <summary>
	/// Интерфейс для классов содержащих оперативные данные пользователя.
	/// </summary>
	public interface ISession
	{		
		/// <summary>
		/// Получает бюджет.
		/// </summary>
		Budget Budget { get; }

		/// <summary>
		/// Получает список шаблонов операций.
		/// </summary>
		ObservableCollection<OperationTemplate> OperationTemplates { get; }

		/// <summary>
		/// Получает флаг модификации текущей сессси.
		/// </summary>
		bool IsDerty { get; }

		/// <summary>
		/// Получает список тегов из операций счетов.
		/// </summary>
		List<string> Tags { get; }
	}
}
