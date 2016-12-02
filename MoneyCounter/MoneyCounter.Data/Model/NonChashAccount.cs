
namespace MoneyCounter.Data.Model
{
	/// <summary>
	/// Cчет с безналичными дньгами.
	/// </summary>
	public class NonChashAccount : Account
	{
		/// <summary>
		/// Получает или задает номер счета.
		/// </summary>
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
