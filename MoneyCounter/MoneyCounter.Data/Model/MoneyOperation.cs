﻿using Catel.Data;

namespace MoneyCounter.Data.Model
{
	/// <summary>
	/// Класс операций с деньгой.
	/// </summary>
	public class MoneyOperation : ObservableObject
	{
		/// <summary>
		/// Получает или задает имя операции.
		/// </summary>
		private string _OperationName;

		/// <summary>
		/// Получает или задает имя операции.
		/// </summary>
		public string OperationName
		{
			get { return _OperationName; }
			set
			{
				if (_OperationName == value)
					return;

				_OperationName = value;
				RaisePropertyChanged(nameof(OperationName));
			}
		}
		
		/// <summary>
		/// Получает или задает вуличину денежной операции.
		/// </summary>
		private double _Value;

		/// <summary>
		/// Получает или задает вуличину денежной операции.
		/// </summary>
		public double Value
		{
			get { return _Value; }
			set
			{
				if (_Value == value)
					return;

				_Value = value;
				RaisePropertyChanged(nameof(Value));
				RaisePropertyChanged(nameof(OperationDirection));
			}
		}

		/// <summary>
		/// Получает направление операции.
		/// </summary>
		public OperationDirection OperationDirection => _Value > 0 ? OperationDirection.Income : OperationDirection.Output;
	}
}