using Catel.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

namespace MoneyCounter.Data.Model
{
	/// <summary>
	/// Класс-родитель кошелек-счет с операциями.
	/// </summary>
	public abstract class Account : ObservableObject
	{
		public Account()
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
		/// Получает занчение баланса кошельк-счета.
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

		/// <summary>
		/// Получает коллекцию тегов всех операции в кошельк-счете.
		/// </summary>
		public List<string> Tags => MoneyOperations.SelectMany(opration => opration.Tags).Distinct().ToList();

		/// <summary>
		/// Получает или задает описание кошельк-счета.
		/// </summary>
		public string Description { get; private set; }
	}
}
