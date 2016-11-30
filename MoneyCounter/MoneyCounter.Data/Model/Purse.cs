using Catel.Data;
using System.Collections.ObjectModel;
using System.Linq;

namespace MoneyCounter.Data.Model
{
	/// <summary>
	/// Кошелек с операциями.
	/// </summary>
	public class Purse : ObservableObject
	{
		public Purse()
		{
			MoneyOperations = new ObservableCollection<MoneyOperation>();
		}

		/// <summary>
		/// Получает занчение баланса кошелька.
		/// </summary>
		public double Balance => MoneyOperations.Sum(operation => operation.Value);

		public ObservableCollection<MoneyOperation> MoneyOperations { get; }
	}
}
