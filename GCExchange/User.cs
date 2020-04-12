using System;
using System.Collections.Generic;
using System.Text;

namespace GCExchange
{
	class User
	{
		#region Properties

		public string Name { get; set; }
		public string EmailAddress { get; set; }
		public int BankAccountNo { get; set; }
		public int BankRoutingNo { get; set; }
		public string Address { get; set; }
		public decimal Balance { get; set; }

		#endregion

		#region Methods

		public void Deposit(decimal amount)
		{
			Balance += amount;
		}

		public decimal Withdraw(decimal amount)
		{
			Balance -= amount;
			return Balance;
		
		}

		
		#endregion

	}

}
