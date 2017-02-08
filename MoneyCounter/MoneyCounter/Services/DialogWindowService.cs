using System;
using System.Collections.Generic;
using System.Windows;

namespace MoneyCounter.Services
{
	/// <summary>
	/// Класс сервиса работы с диалоговыми окнами.
	/// </summary>
	public class DialogWindowService : IDialogWindowService
	{
		public DialogWindowService()
		{
			_DialogWindow = new Dictionary<Type, Type>();
		}

		/// <summary>
		/// Привязка модели представления данных к окну.
		/// </summary>
		private readonly Dictionary<Type, Type> _DialogWindow;

		/// <inheritdoc />
		public void Register(Type viewModel, Type window)
		{
			if (_DialogWindow.ContainsKey(viewModel))
				_DialogWindow[viewModel] = window;
			else
				_DialogWindow.Add(viewModel, window);
		}

		/// <inheritdoc />
		public void ShowDialog(object viewModelValue)
		{
			var viewModelValueType = viewModelValue.GetType();

			Type windowType;

			if (_DialogWindow.TryGetValue(viewModelValueType, out windowType))
			{
				var window = (Window)Activator.CreateInstance(windowType);

				window.DataContext = viewModelValue;
				window.ShowDialog();
			}
		}
	}
}
