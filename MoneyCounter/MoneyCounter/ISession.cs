using MoneyCounter.Data.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MoneyCounter
{
	public interface ISession
	{
		/// <summary>
		/// Получает буджет.
		/// </summary>
		Budget Budget { get; }

		/// <summary>
		/// Получает список шаблонов операций.
		/// </summary>
		ObservableCollection<OperationTemplate> OperationTemplates { get; }

		/// <summary>
		/// Получает трекинг отслеживания модификации данной сессии.
		/// </summary>
		bool IsDerty { get; }

		/// <summary>
		/// Получает список тегов из операций счетов.
		/// </summary>
		List<string> Tags { get; }
	}
}
