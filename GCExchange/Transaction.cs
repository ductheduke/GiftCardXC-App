using System;
using System.Collections.Generic;
using System.Text;

namespace GCExchange
{
	enum TypeOfTransaction
	{
		Credit,
		Debit
	}

	class Transaction
	{
		public int TransactionID { get; set; }
		public DateTime TransactionDate { get; set; }
		public decimal Amount { get; set; }
		public TypeOfTransaction TransactionType { get; set; }
		public int UserID { get; set; }
	}
}
