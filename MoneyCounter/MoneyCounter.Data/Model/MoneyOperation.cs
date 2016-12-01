using System;
using Catel.Data;

namespace MoneyCounter.Data.Model
{
	/// <summary>
	/// Класс операций с деньгой.
	/// </summary>
	public class MoneyOperation : ObservableObject
	{
		/// <summary>
		/// Метод инициалиации операции с заданными именем и величиной.
		/// </summary>
		/// <param name="value">значение операции</param>
		/// <param name="operationName">имя операции</param>
		public void Initialaze(double value, string operationName)
		{
			Value = value;
			OperationName = operationName;
		}

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
		/// Получает или задает величину денежной операции.
		/// </summary>
		private double _Value;

		/// <summary>
		/// Получает или задает величину денежной операции.
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
