using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MoneyCounter.Data.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;

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
		/// <param name="filePath">путь к файлу</param>
		/// <returns>сессия</returns>
		public static Session Load(string filePath)
		{			
			if (!File.Exists(filePath))
				return null;

			Session result = null;
			using (var reader = File.OpenRead(filePath))
				result = JsonConvert.DeserializeObject<Session>(reader.ToString());		
			
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
