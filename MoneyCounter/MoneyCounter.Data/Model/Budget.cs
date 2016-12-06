using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

namespace MoneyCounter.Data.Model
{
	/// <summary>
	/// Общий бюджет.
	/// </summary>
	[DataContract]
	public class Budget
	{
		public Budget()
		{
			_CashAccounts = new ObservableCollection<CashAccount>();
			_NonCashAccounts = new ObservableCollection<NonCashAccount>();
		}

		/// <summary>
		/// Коллекция наличных счетов.
		/// </summary>
		[DataMember(Name = "CashAccounts")]
		private ObservableCollection<CashAccount> _CashAccounts;
		
		/// <summary>
		/// Коллекция безналичных счетов.
		/// </summary>
		[DataMember(Name = "NonCashAccounts")]
		private ObservableCollection<NonCashAccount> _NonCashAccounts;
		
		/// <summary>
		/// Добавляет счет.
		/// </summary>
		/// <param name="account">Счет.</param>
		public void AddAccount(Account account)
		{
			if (account == null)
				throw new ArgumentNullException(nameof(account));

			if (account is CashAccount)
				_CashAccounts.Add((CashAccount) account);
			else if (account is NonCashAccount)
				_NonCashAccounts.Add((NonCashAccount) account);
			else				
				throw new ArgumentOutOfRangeException(nameof(account));
		}

		/// <summary>
		/// Получает или задает коллекцию счетов.
		/// </summary>		
		public IReadOnlyCollection<Account> Accounts
		{
			get
			{
				var result = new List<Account>();
				foreach (var account in _CashAccounts)
					result.Add(account);

				foreach (var account in _NonCashAccounts)
					result.Add(account);

				return new ReadOnlyCollection<Account>(result);
			}
		}
	
		/// <summary>
		/// Получает общий баланс всех счетов.
		/// </summary>
		public double Balance => Accounts.Sum(account => account.Balance);
	}
}
