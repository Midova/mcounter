
namespace MoneyCounter.Data.Model
{
	/// <summary>
	/// Кошелк-счет с безналичными дньгами
	/// </summary>
	public class NonChashAccount : Account
	{
		/// <summary>
		/// Получает или задает номер счета.
		/// </summary>
		public string AccountNumber { get; private set; }
	}
}
