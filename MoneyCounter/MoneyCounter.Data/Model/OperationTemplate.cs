using Catel.Data;
using System.Collections.Generic;

namespace MoneyCounter.Data.Model
{
	/// <summary>
	/// Класс шаблон денежной операции.
	/// </summary>
	public class OperationTemplate : ObservableObject
	{		
		public OperationTemplate()
		{
			Tags = new List<string>();
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
			}
		}

		/// <summary>
		/// Получает или задает коллекцию тегов операции.
		/// </summary>
		public List<string> Tags { get; private set; }

		/// <summary>
		/// Создает операцию на основе существующего шаблона. 
		/// </summary>
		/// <returns>Oперация на основе существующего шаблона.</returns>
		public MoneyOperation CreateMoneyOperation()
		{
			var operation = new MoneyOperation() { OperationName = OperationName, Value = Value };
			operation.Tags.AddRange(Tags);
			return operation;
		}
	}	
}
