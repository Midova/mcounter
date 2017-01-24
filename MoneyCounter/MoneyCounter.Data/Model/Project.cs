using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

namespace MoneyCounter.Data.Model
{
	/// <summary>
	/// Класс, содержащий оперативные данные пользователя.
	/// </summary>	
	[DataContract]
	public class Project : IProject
	{		
		public Project()
		{
			OperationTemplates = new ObservableCollection<OperationTemplate>();			
			IsDerty = false;
		}
		
		/// <summary>
		/// Инициализирует проект.
		/// </summary>
		/// <param name="budget">Бюджет для инициализации сессии.</param>
		public void Initialize(Budget budget)
		{
			Budget = budget;
		}

		/// <summary>
		/// Получает бюджет.
		/// </summary>
		[DataMember]
		public Budget Budget { get; private set; }

		/// <summary>
		/// Получает флаг модификации текущего проекта.
		/// </summary>
		[DataMember]
		public bool IsDerty { get; }

		/// <summary>
		/// Получает список шаблонов операций.
		/// </summary>
		[DataMember]
		public ObservableCollection<OperationTemplate> OperationTemplates { get; }

		/// <summary>
		/// Получает теги из операций счетов текущего бюджета.
		/// </summary>		
		public List<string> Tags => Budget.Accounts.SelectMany(opration => opration.Tags).Distinct().ToList();		
	}
}
