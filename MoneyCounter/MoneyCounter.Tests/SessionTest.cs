﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

			var cashAccount = new CashAccount { Description = "Cash account" };
			cashAccount.AddOperation(new MoneyOperation()
			{
				OperationName = "Зарплата",
				OperationDate = DateTime.Today,
				Tags = { "Вова" },
				Value = 5
			});

			var nonCashaccount = new NonCashAccount { Description = "Non-Cash account" };
			nonCashaccount.AddOperation(new MoneyOperation()
			{
				OperationName = "Налог",
				OperationDate = new DateTime(2016, 12, 05),
				Tags = { "Даша", "машина", "Вова" },
				Value = -2
			});

			budget.AddAccount(cashAccount);
			budget.AddAccount(nonCashaccount);
						
			return budget;
		}
	}
}
