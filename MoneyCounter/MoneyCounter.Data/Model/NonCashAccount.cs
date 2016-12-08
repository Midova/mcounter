
using System.Runtime.Serialization;

namespace MoneyCounter.Data.Model
{
	/// <summary>
	/// Cчет с безналичными дньгами.
	/// </summary>
	[DataContract]
	public class NonCashAccount : Account
	{
		/// <summary>
		/// Получает или задает номер счета.
		/// </summary>
		[DataMember(Name = nameof(AccountNumber))]
		public string _AccountNumber;

		/// <summary>
		/// Получает или задает номер счета.
		/// </summary>
		public string AccountNumber
		{
			get { return _AccountNumber; }
			set
			{
				if (_AccountNumber == value)
					return;

				_AccountNumber = value;
				RaisePropertyChanged(nameof(AccountNumber));
			}
		}
	}
}
