using System;

namespace GCExchange
{
	class Program
	{
		static void Main(string[] args)
		{
			//Create an instance of class User == object 
			var FirstUser = GC.Register("Jason Bateman", "jason@gmail.com", TypeOfUser.Buyer);
			FirstUser.BankAccountNo = 123456;
			FirstUser.BankRoutingNo = 111110;
			FirstUser.Address = "123 King Street";
			FirstUser.Deposit(100);
			Console.WriteLine($"User ID: {FirstUser.UserID}, User Name: {FirstUser.UserName}, User Type: {FirstUser.UserType}, Email: {FirstUser.EmailAddress}");

			var SecondUser = GC.Register("Helen Pierce", "helen@msn.com", TypeOfUser.Seller);
			SecondUser.BankAccountNo = 2141452;
			SecondUser.BankRoutingNo = 3365525;
			SecondUser.Address = "456 Downing Avenue";
			Console.WriteLine($"User ID: {SecondUser.UserID}, User Name: {SecondUser.UserName}, User Type: {SecondUser.UserType}, Email: {SecondUser.EmailAddress}");
		}
	}
}
