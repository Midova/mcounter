using Catel.Data;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

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
			MoneyOperations.CollectionChanged += (sender, args) => RaisePropertyChanged(nameof(Balance));
		}

		/// <summary>
		/// При десериализации востанавливает подписку на изменение коллкции MoneyOperations.
		/// </summary>
		/// <param name="context">Контекст.</param>
		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{
			MoneyOperations.CollectionChanged += (sender, args) => RaisePropertyChanged(nameof(Balance));
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
