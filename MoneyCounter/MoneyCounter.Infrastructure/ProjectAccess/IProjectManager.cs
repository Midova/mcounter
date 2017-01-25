using MoneyCounter.Data.Model;

namespace MoneyCounter.Infrastructure.ProjectAccess
{
	/// <summary>
	/// Интерыфейс для класса управления проектом.
	/// </summary>
	public interface IProjectManager
	{
		/// <summary>
		/// Текущий проект.
		/// </summary>
		Project Project { get; }

		/// <summary>
		/// Cозданиe новой сессии.
		/// </summary>
		void CreateNewProject();

		/// <summary>
		/// Загрузка проекта из файла.
		/// </summary>
		void LoadProject();

		/// <summary>
		/// Сохранение проекта в файл.
		/// </summary>
		void SaveProject();

		/// <summary>
		/// Cохранение проекта в файл по новому адресу.
		/// </summary>
		void SaveAsProject();

		/// <summary>
		/// Изменялся ли проект.
		/// </summary>
		/// <returns><c>true</c>- сессия менялась, <c>false</c> - иначе.</returns>
		bool CanSaveProject();

		/// <summary>
		/// Закрытие проекта, с сохранением или без.
		/// </summary>
		void CloseProject();

		/// <summary>
		/// Загружался ли проект.
		/// </summary>
		/// <returns><c>true</c>- если сессия заполнена, <c>false</c>- иначе.</returns>
		bool CanCloseProject();
	}
}
