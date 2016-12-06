using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MoneyCounter.Data.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;
using System.Runtime.Serialization;

namespace MoneyCounter
{
	/// <summary>
	/// Класс, содержащий оперативные данные пользователя.
	/// </summary>	
	[DataContract]
	public class Session : ISession
	{
		public Session()
		{
			OperationTemplates = new ObservableCollection<OperationTemplate>();
		}

		/// <summary>
		/// Инициализирует сессию.
		/// </summary>
		/// <param name="budget">Бюджет для инициализации сессии.</param>
		public void Initialize(Budget budget)
		{
			Budget = budget;
		}

		/// <summary>
		/// Получает буджет.
		/// </summary>
		[DataMember]
		public Budget Budget { get; private set; }

		/// <summary>
		/// Получает трекинг отслеживания модификации данной сессии.
		/// </summary>
		[DataMember]
		public bool IsDerty { get; }

		/// <summary>
		/// Получает список шаблонов операций.
		/// </summary>
		[DataMember]
		public ObservableCollection<OperationTemplate> OperationTemplates { get; }

		/// <summary>
		/// Получает теги из операций счетов текущего буджета.
		/// </summary>		
		public List<string> Tags => Budget.Accounts.SelectMany(opration => opration.Tags).ToList();

		/// <summary>
		/// Выполняет дисериализацию сессии из указанного файла.
		/// </summary>
		/// <param name="filePath">путь к файлу</param>
		/// <returns>сессия</returns>
		public static Session Load(string filePath)
		{			
			if (!File.Exists(filePath))
				return null;

			Session result = null;

			var content = File.ReadAllText(filePath);
			result = JsonConvert.DeserializeObject<Session>(content);
			
			return result;
		}

		/// <summary>
		/// Выполняет сериализацию сессии по указанному пути.
		/// </summary>
		/// <param name="filePath">путь к файлу</param>
		/// <param name="session">нынешняя сессия</param>
		public static void Save(string filePath, Session session)
		{			
			JsonSerializer serializer = new JsonSerializer();
			serializer.Converters.Add(new JavaScriptDateTimeConverter());

			serializer.NullValueHandling = NullValueHandling.Ignore;

			using (StreamWriter sw = new StreamWriter(filePath))
			using (JsonWriter writer = new JsonTextWriter(sw))
			{
				serializer.Serialize(writer, session);
				writer.Close();
			}
		}
	}
}
