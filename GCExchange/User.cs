using System;
using System.Collections.Generic;
using System.Text;

namespace GCExchange
{
	class User
	{
		private static int lastUserID = 0;

		#region Properties
		public int UserID { get; private set; }
		public string UserName { get; set; }
		public string EmailAddress { get; set; }
		public decimal Balance { get; private set; }
		public DateTime CreatedDate { get; private set; }
		#endregion

		#region Constructor
		public User()
		{
			UserID = lastUserID++;
			CreatedDate = DateTime.Now;
		}
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
