using System;

namespace GCExchange
{
	class Program
	{
		static void Main(string[] args)
		{
			//Create an instance of class User == object 
			var User1 = new User();
			User1.Name = "Jason Bateman";
			User1.EmailAddress = "jason@gmail.com";
			User1.BankAccountNo = 123456;
			User1.BankRoutingNo = 111110;
			User1.Address = "123 King Street";
			User1.Deposit(100);

			var User2 = new User();
			User1.Name = "Helen Pierce";
			User1.EmailAddress = "helen@msn.com";
			User1.BankAccountNo = 2141452;
			User1.BankRoutingNo = 3365525;
			User1.Address = "456 Downing Avenue";
		}
	}
}
