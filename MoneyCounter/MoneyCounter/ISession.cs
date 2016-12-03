﻿using MoneyCounter.Data.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyCounter
{
	public interface ISession
	{
		/// <summary>
		/// Получает буджет.
		/// </summary>
		Budget Butget { get; }

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
