using Catel.Data;

namespace MoneyCounter.Data.Model
{
	/// <summary>
	/// Класс шаблон денежной операции.
	/// </summary>
	public class OperationTemplate : ObservableObject
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
		/// Создает операцию на основе существующего шаблона. 
		/// </summary>
		/// <returns>Oперация на основе существующего шаблона.</returns>
		public MoneyOperation CreateMoneyOperation()
		{
			var operation = new MoneyOperation() { Value = Value, OperationName = OperationName };				
			return operation;
		}
	}	
}
