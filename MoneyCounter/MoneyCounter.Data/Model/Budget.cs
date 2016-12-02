using System.Collections.ObjectModel;
using System.Linq;

namespace MoneyCounter.Data.Model
{
	/// <summary>
	/// Общий бюджет.
	/// </summary>
	public class Budget
	{
		/// <summary>
		/// Получает задает коллекцию кошельк-счетов.
		/// </summary>
		public ObservableCollection<Account> Accounts { get; private set; }

		/// <summary>
		/// Получает общий (глобальный) баланс всех кошельков.
		/// </summary>
		public double GlobalBalance => Accounts.Sum(account => account.Balance);
	}
}
