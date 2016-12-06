using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyCounter.Data.Model;

namespace MoneyCounter.Tests
{
	/// <summary>
	/// Тесты класса Session.
	/// </summary>
	[TestClass]
	public class SessionTest
	{
		/// <summary>
		/// Адресс файла для теста.
		/// </summary>
		private const string SessionFilePath = "session.mcounter";

		/// <summary>
		/// Тест метода Save в классе Session.
		/// </summary>
		[TestMethod]	
		public void Session_Save()
		{
			var session = new Session();
			session.Initialize(PopulateData());

			Session.Save(SessionFilePath, session);
		}

		/// <summary>
		/// Тест метода Load в классе Session.
		/// </summary>
		[TestMethod]
		public void Session_Load()
		{
			Assert.IsNotNull(Session.Load(SessionFilePath));			
		}

		/// <summary>
		/// Создание и заполнение тестового класса Budget.
		/// </summary>
		/// <returns>Заболненный класс Budget./returns>
		private Budget PopulateData()
		{
			var budget = new Budget();
			var accounts = 
				new Account[] 
				{
					new CashAccount
					{
						Description = "Cash account"
					},
					new NonCashAccount
					{
						Description = "Non-Cash account"
					}
				};

			foreach (var account in accounts)
				budget.AddAccount(account);

			return budget;
		}
	}
}
