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
			OperationTemplates = new ObservableCollection<OperationTemplate>();
		}

		/// <summary>
		/// Получает занчение баланса кошелька.
		/// </summary>
		public double Balance => MoneyOperations.Sum(operation => operation.Value);

		/// <summary>
		/// Получает список операций.
		/// </summary>
		public ObservableCollection<MoneyOperation> MoneyOperations { get; }

		/// <summary>
		/// Получает список шаблонов операций.
		/// </summary>
		public ObservableCollection<OperationTemplate> OperationTemplates { get; }
	}
}
