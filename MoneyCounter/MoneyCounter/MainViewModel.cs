using Catel.MVVM;
using MoneyCounter.Services;
using System.Windows.Input;
using Catel.Data;
using MoneyCounter.Infrastructure.Session;
using MoneyCounter.Data.Model;

namespace MoneyCounter
{
	/// <summary>
	/// Класс, работы с главным окном.
	/// </summary>
	public class MainViewModel : ObservableObject
	{
		public MainViewModel(IOpenProjectFileService fileOpenDialogService,
			ISaveProjectFileService fileSaveDialogService, IConfirmationRequestService confirmationRequestService, IDialogWindowService dialogWindowService)
		{
			_DialogWindowService = dialogWindowService;

			_ProjectManager = new ProjectManager(confirmationRequestService, fileOpenDialogService, fileSaveDialogService);

			OpenProjectCommand = new Command(_ProjectManager.LoadProject);
			SaveProjectCommand = new Command(_ProjectManager.SaveProject, _ProjectManager.CanSaveProject);
			SaveAsProjectCommand = new Command(_ProjectManager.SaveAsProject);

			CloseProjectCommand = new Command(_ProjectManager.CloseProject, _ProjectManager.CanCloseProject);
			CreateNewProjectCommand = new Command(_ProjectManager.CreateNewProject);

			PropertyChanged += MainViewModel_PropertyChanged;

			ShowAboutWindowCommand = new Command(ShowAboutWindow);
		}

		/// <summary>
		/// Изменение свойств модели главного окна.
		/// </summary>
		/// <param name="sender">Измененное свойство.</param>
		/// <param name="e">Данные для события.</param>
		private void MainViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			((Command)CloseProjectCommand).RaiseCanExecuteChanged();
			((Command)SaveAsProjectCommand).RaiseCanExecuteChanged();
			((Command)SaveProjectCommand).RaiseCanExecuteChanged();
		}
		#region Infrastructura

		/// <summary>
		/// Сервис работы с диалоговым окном.
		/// </summary>
		private IDialogWindowService _DialogWindowService;

		#endregion

		#region Project Management

		/// <summary>
		/// Менеджер проекта.
		/// </summary>
		private ProjectManager _ProjectManager;		

		/// <summary>
		/// Текущий проект.
		/// </summary>
		public Project Project => _ProjectManager.Project;

		/// <summary>
		/// Получает команду создания нового проекта.
		/// </summary>
		public ICommand CreateNewProjectCommand { get; private set; }

		/// <summary>
		/// Получает команду загрузки проекта из файла.
		/// </summary>
		public ICommand OpenProjectCommand { get; private set; }

		/// <summary>
		/// Получает команду сохранения проекта в файл.
		/// </summary>
		public ICommand SaveProjectCommand { get; private set; }

		/// <summary>
		/// Получает команду сохранения проекта в файл по новому адресу.
		/// </summary>
		public ICommand SaveAsProjectCommand { get; private set; }

		/// <summary>
		/// Получает команду закрытия проекта.
		/// </summary>
		public ICommand CloseProjectCommand { get; private set; }

		#endregion

		/// <summary>
		/// Получает команду показа окна информации о программе.
		/// </summary>
		public ICommand ShowAboutWindowCommand { get; private set; }

		/// <summary>
		/// Показывает окно информации о программе.
		/// </summary>
		private void ShowAboutWindow()
		{
			_DialogWindowService.ShowDialog(new AboutWindowModel());
		}
	}
}
