using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MoneyCounter.Data.Model;

namespace MoneyCounter
{
	/// <summary>
	/// Класс, содержащий оперативные данные пользователя.
	/// </summary>
	public class Session : ISession
	{
		public Session()
		{
			OperationTemplates = new ObservableCollection<OperationTemplate>();
		}

		/// <summary>
		/// Получает буджет.
		/// </summary>
		public Budget Budget { get; }

		/// <summary>
		/// Получает трекинг отслеживания модификации данной сессии.
		/// </summary>
		public bool IsDerty { get; }

		/// <summary>
		/// Получает список шаблонов операций.
		/// </summary>
		public ObservableCollection<OperationTemplate> OperationTemplates { get; }

		/// <summary>
		/// Получает теги из операций счетов текущего буджета.
		/// </summary>
		public List<string> Tags => Budget.Accounts.SelectMany(opration => opration.Tags).Distinct().ToList();

		/// <summary>
		/// Выполняет дисериализацию сессии из указанного файла.
		/// </summary>
		/// <param name="filePath"></param>
		/// <returns></returns>
		public static Session Load(string filePath)
		{
						
		}

		/// <summary>
		/// Выполняет сериализацию сессии по указанному пути
		/// </summary>
		/// <param name="filePath"></param>
		public static void Save(string filePath)
		{

		}
	}
}
