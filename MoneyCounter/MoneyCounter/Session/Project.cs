using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MoneyCounter.Data.Model;
using Newtonsoft.Json;
using System.IO;
using System.Runtime.Serialization;

namespace MoneyCounter.Session
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
			FilePath = string.Empty;
			IsDerty = false;
		}

		/// <summary>
		/// Разрешение файла, для сохранения данного проекта.
		/// </summary>
		public const string FileExtension = ".mcounter";

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

		/// <summary>
		/// Получает или задает путь к файлу проекта.
		/// </summary>
		public string FilePath { get; set; }

		/// <summary>
		/// Выполняет дисериализацию проекта по указанному пути.
		/// </summary>
		/// <param name="filePath">Путь к файлу проекта.</param>
		/// <returns>Данные из файла проекта.</returns>
		public static Project Load(string filePath)
		{			
			if (!File.Exists(filePath))
				return null;

			Project result = null;

			var content = File.ReadAllText(filePath);
			result = JsonConvert.DeserializeObject<Project>(content);
			
			return result;
		}

		/// <summary>
		/// Выполняет сериализацию проекта по указанному пути.
		/// </summary>
		/// <param name="filePath">Путь к файлу проекта.</param>
		/// <param name="project">Текущий проект.</param>
		public static void Save(string filePath, Project project)
		{			
			JsonSerializer serializer = new JsonSerializer();
			
			using (StreamWriter sw = new StreamWriter(filePath))
			using (JsonWriter writer = new JsonTextWriter(sw))
			{
				serializer.Serialize(writer, project);
				writer.Close();
			}
		}
	}
}
