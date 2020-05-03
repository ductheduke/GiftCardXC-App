using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCExchange
{
	static class Exchange
	{
		private static List<User> users = new List<User>();
		private static List<Card> cards = new List<Card>();
		private static List<Transaction> transactions = new List<Transaction>();
		

		public static User Register(string userName,
									string emailAddress,
									decimal initialAmount = 0)
		{
			var user = new User
			{
				UserName = userName,
				EmailAddress = emailAddress,
			};
			users.Add(user);

			if (initialAmount > 0)
			{
				Deposit(user.UserID, initialAmount);
			}
			///db.Accounts.Add(account);
			///db.SaveChanges();
			return user;
		}


		public static Card List(string vendorName, 
								decimal cardAmount,
								string emailAddress)
		{
			var card = new Card
			{
				VendorName = vendorName,
				CardAmount = cardAmount,
				EmailAddress = emailAddress,
			};
			cards.Add(card);

			///db.Accounts.Add(account);
			///db.SaveChanges();
			return card;
		}


		public static IEnumerable<User> GetUsers(string emailAddress)
		{
			return users.Where(a => a.EmailAddress == emailAddress);
		}


		public static IEnumerable<Card> GetCards(string emailAddress)
		{
			return cards.Where(a => a.EmailAddress == emailAddress);
		}


		public static IEnumerable<User> GetBalance(string emailAddress)
		{
			return users.Where(a => a.EmailAddress == emailAddress);
		}


		public static IEnumerable<Transaction> GetTransactionsByUserID(int userID)
		{
			return transactions
					.Where(t => t.UserID == userID)
					.OrderByDescending(t => t.TransactionDate);
		}


		public static void Deposit(int userID, decimal amount)
		{
			// Locate the account using LINQ
			var user = users.SingleOrDefault(user => user.UserID == userID);
			// Deposit amount into the account
			user.Deposit(amount);
			// Log the transaction
			var transaction = new Transaction
			{
				TransactionDate = DateTime.Now,
				Amount = amount,
				TransactionType = TypeOfTransaction.Credit,
				UserID = userID
			};
			transactions.Add(transaction);
			//db.SaveChanges();
		}

		public static void Withdraw(int userID, decimal amount)
		{
			// Locate the account using LINQ
			var user = users.SingleOrDefault(user => user.UserID == userID);
			// Withdraw amount from the account
			user.Withdraw(amount);
			// Log the transaction
			var transaction = new Transaction
			{
				TransactionDate = DateTime.Now,
				Amount = amount,
				TransactionType = TypeOfTransaction.Debit,
				UserID = userID
			};
			transactions.Add(transaction);
			//db.SaveChanges();
		}


	}
}