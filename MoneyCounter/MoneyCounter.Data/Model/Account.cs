using Catel.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

namespace MoneyCounter.Data.Model
{
	/// <summary>
	/// Счет с операциями.
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
		/// Получает или задает описание счета.
		/// </summary>
		private string _Description;

		/// <summary>
		/// Получает или задает описание счета.
		/// </summary>
		public string Description
		{
			get { return _Description; }
			set
			{
				if (_Description == value)
					return;

				_Description = value;
				RaisePropertyChanged(nameof(Description));
			}
		}

		/// <summary>
		/// Получает занчение баланса счета.
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
		/// Получает коллекцию тегов всех операции в счете.
		/// </summary>
		public List<string> Tags => MoneyOperations.SelectMany(opration => opration.Tags).Distinct().ToList();		
	}
}
