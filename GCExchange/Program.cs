using System;

namespace GCExchange
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("****Welcome to the largest Gift Card Marketplace in the world!****");
			while (true)
			{
				Console.WriteLine("0. Exit");
				Console.WriteLine("1. Buy Gift Cards");
				Console.WriteLine("2. Sell Gift Cards");
				Console.WriteLine("3. Deposit Funds");
				Console.WriteLine("4. Withdraw Funds");
				Console.WriteLine("5. View Account Balance");
				Console.WriteLine("6. View List of Cards for Sale");
				Console.WriteLine("7. View Transaction Log");

				var option = Console.ReadLine();
				switch (option)
				{
					case "0":
						Console.WriteLine("Thank you for visiting the exchange!");
						return;

					case "1":
						Console.Write("What's your Name? ");
						var userName = Console.ReadLine();

						Console.Write("What's your Email Address? ");
						var emailAddress = Console.ReadLine();

						Console.WriteLine("Amount to deposit to buy gift card: ");
						var amount = Convert.ToDecimal(Console.ReadLine());

						var user = Exchange.Register(userName, emailAddress, amount);
						Console.WriteLine("Your buyer account has been created! Here's your account details and Happy Shopping!");
						Console.WriteLine($"UserID: {user.UserID}, Name: {user.UserName}, Email: {user.EmailAddress}, B: {user.Balance:C}, CD: {user.CreatedDate}");
						break;

					case "2":
						Console.Write("What's your Email Address? ");
						emailAddress = Console.ReadLine();

						Console.Write("What's the Vendor Name of your Gift Card? ");
						var vendorName = Console.ReadLine();
						
						Console.Write("What's the Card Amount? ");
						var cardAmount = Convert.ToDecimal(Console.ReadLine());

						Exchange.List(vendorName, cardAmount, emailAddress);
						Console.WriteLine("Your card is now listed for sale!");
						break;

					case "3":
						PrintAllUserIDs();

						Console.Write("Select your UserID above: ");
						var userID = Convert.ToInt32(Console.ReadLine());

						Console.Write("Amount to Deposit: ");
						amount = Convert.ToDecimal(Console.ReadLine());

						Exchange.Deposit(userID, amount);
						Console.WriteLine("Deposit successfully completed!");
						break;

					case "4":
						PrintAllUserIDs();

						Console.Write("Select your UserID above: ");
						userID = Convert.ToInt32(Console.ReadLine());

						Console.Write("Amount to Withdraw: ");
						amount = Convert.ToDecimal(Console.ReadLine());

						Exchange.Withdraw(userID, amount);
						Console.WriteLine("Withdrawal successfully completed!");
						break;

					case "5":
						ViewAccountBalance();
						break;

					case "6":
						PrintAllCards();
						break;

					case "7":
						PrintAllUserIDs();

						Console.Write("Select your UserID above: ");
						userID = Convert.ToInt32(Console.ReadLine());

						var transactions = Exchange.GetTransactionsByUserID(userID);
						foreach (var transaction in transactions)
						{
							Console.WriteLine($"TD: {transaction.TransactionDate}, TA: {transaction.Amount:C}, TT: {transaction.TransactionType}, AN: {transaction.UserID}");
						}
						break;

					default:
						Console.WriteLine("Invalid choice! Please try again.");
						break;
				}
			}
		}


		private static void PrintAllUserIDs()
		{
			Console.Write("What's your Email Address? ");
			var emailAddress = Console.ReadLine();
			var users = Exchange.GetUsers(emailAddress);
			if (users == null)
			{
				Console.WriteLine("No account is associated with this email address!");
				return;
			}
			foreach (var a in users)
			{
				Console.WriteLine($"User ID: {a.UserID}, Email Address: {a.EmailAddress}, Created Date: {a.CreatedDate}");
			}
		}


		private static void PrintAllCards()
		{
			Console.Write("What's your Email Address? ");
			var emailAddress = Console.ReadLine();
			var cards = Exchange.GetCards(emailAddress);
			if (cards == null)
			{
				Console.WriteLine("No account is associated with this email address!");
				return;
			}
			foreach (var a in cards)
			{
				Console.WriteLine($"Card ID: {a.CardID}, Vendor Name: {a.VendorName}, Card Amount: {a.CardAmount}, Email Address: {a.EmailAddress}, Listing Date: {a.ListingDate}");
			}
		}


		private static void ViewAccountBalance()
		{
			Console.Write("What's your Email Address? ");
			var emailAddress = Console.ReadLine();
			var users = Exchange.GetBalance(emailAddress);
			if (users == null)
			{
				Console.WriteLine("No account is associated with this email address!");
				return;
			}
			foreach (var a in users)
			{
				Console.WriteLine($"User ID: {a.UserID}, User Name: {a.UserName}, Account Balance: {a.Balance:C}");
			}
		}
	}
}
