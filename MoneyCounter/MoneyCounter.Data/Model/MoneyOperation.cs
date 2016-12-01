using System;
using Catel.Data;
using System.Collections.Generic;

namespace MoneyCounter.Data.Model
{
	/// <summary>
	/// Класс операций с деньгой.
	/// </summary>
	public class MoneyOperation : ObservableObject
	{
		public MoneyOperation()
		{
			Tags = new List<string>();
		}

		public MoneyOperation(string operationName, double value, List<string> tags)
		{
			_OperationName = operationName;
			_Value = value;
			Tags = tags;
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

		/// <summary>
		/// Получает и задает дату проведения операции.
		/// </summary>
		private DateTime _OperationDate;

		/// <summary>
		/// Получает и задает дату проведения операции.
		/// </summary>
		public DateTime OperationDate
		{
			get { return _OperationDate; }
			set
			{
				if (_OperationDate == value)
					return;

				_OperationDate = value;
				RaisePropertyChanged(nameof(OperationDate));
			}
		}

		/// <summary>
		/// Получает или задает коллекцию тегов операции.
		/// </summary>
		public List<string> Tags { get; private set; }
	}
}
