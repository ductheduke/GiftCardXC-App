using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GCExchange
{
	static class Exchange
	{
		private static ExchangeContext db = new ExchangeContext();

		public static User Register(string userName,
									string emailAddress,
									decimal initialAmount = 0)
		{
			var user = new User
			{
				UserName = userName,
				EmailAddress = emailAddress,
			};
			
			db.Users.Add(user);

			if (initialAmount > 0)
			{
				Deposit(user.UserID, initialAmount);
			}
			
			db.SaveChanges();
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
			
			db.Cards.Add(card);
			db.SaveChanges();
			return card;
		}


		public static IEnumerable<User> GetUsers(string emailAddress)
		{
			return db.Users.Where(a => a.EmailAddress == emailAddress);
		}


		public static IEnumerable<Card> GetCards(string emailAddress)
		{
			return db.Cards.Where(a => a.EmailAddress == emailAddress);
		}


		public static IEnumerable<User> GetBalance(string emailAddress)
		{
			return db.Users.Where(a => a.EmailAddress == emailAddress);
		}


		public static IEnumerable<Transaction> GetTransactionsByUserID(int userID)
		{
			return db.Transactions
					.Where(t => t.UserID == userID)
					.OrderByDescending(t => t.TransactionDate);
		}


		public static void Deposit(int userID, decimal amount)
		{
			var user = db.Users.SingleOrDefault(user => user.UserID == userID);
			if (user == null)
			{
				// Raise an exception
				throw new ArgumentException("UserID is invalid!");
			}
			user.Deposit(amount);
			var transaction = new Transaction
			{
				TransactionDate = DateTime.Now,
				Amount = amount,
				TransactionType = TypeOfTransaction.Credit,
				UserID = userID
			};
			db.Transactions.Add(transaction);
			db.SaveChanges();
		}

		public static void Withdraw(int userID, decimal amount)
		{
			var user = db.Users.SingleOrDefault(user => user.UserID == userID);
			if (user == null)
			{
				// Raise an exception
				throw new ArgumentException("UserID is invalid!");
			}
			user.Withdraw(amount);
			var transaction = new Transaction
			{
				TransactionDate = DateTime.Now,
				Amount = amount,
				TransactionType = TypeOfTransaction.Debit,
				UserID = userID
			};
			db.Transactions.Add(transaction);
			db.SaveChanges();
		}
	}
}