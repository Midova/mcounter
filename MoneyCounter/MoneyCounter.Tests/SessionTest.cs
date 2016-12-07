using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyCounter.Data.Model;
using System;

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
			session.OperationTemplates.Add(new OperationTemplate()
			{
				OperationName = "шаблон1",
				Tags = { "дом", "ремонт" },
				Value = 5
			});

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
			
			var account1 = new CashAccount { Description = "Cash account" };
			account1.AddOperation(new MoneyOperation()
			{
				OperationName = "Зарплата",
				OperationDate = DateTime.Today,
				Tags = { "Вова"},
				Value = 5
			});

			var account2 = new NonCashAccount { Description = "Non-Cash account" };
			account2.AddOperation(new MoneyOperation()
			{
				OperationName = "Налог",
				OperationDate = new DateTime(2016, 12, 05),
				Tags = { "Даша", "машина" },
				Value = -2
			});

			budget.AddAccount(account1);
			budget.AddAccount(account2);

			//var accounts =
			//	new Account[]
			//	{
			//		new CashAccount
			//		{
			//			Description = "Cash account",
								
			//		},
			//		new NonCashAccount
			//		{
			//			Description = "Non-Cash account"
			//		}
			//	};
			

			//foreach (var account in accounts)
			//{
			//	budget.AddAccount(account);				
			//}
				
				
			
			return budget;
		}
	}
}
