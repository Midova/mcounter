using Catel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			}
		}

	}
}
