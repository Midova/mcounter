using System.Collections.ObjectModel;
using System.Linq;

namespace MoneyCounter.Data.Model
{
	/// <summary>
	/// Общий бюджет.
	/// </summary>
	public class Budget
	{
		public Budget()
		{
			Accounts = new ObservableCollection<Account>();
		}
		
		/// <summary>
		/// Получает или задает коллекцию счетов.
		/// </summary>
		public ObservableCollection<Account> Accounts { get; private set; }

		/// <summary>
		/// Получает общий баланс всех счетов.
		/// </summary>
		public double Balance => Accounts.Sum(account => account.Balance);
	}
}
