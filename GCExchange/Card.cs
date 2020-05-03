using System;
using System.Collections.Generic;
using System.Text;

namespace GCExchange
{
	class Card
	{
		private static int lastCardID = 0;

		#region Properties
		public int CardID { get; private set; }
		public string VendorName { get; set; }
		public decimal CardAmount { get; set; }
		public string EmailAddress { get; set; }
		public DateTime ListingDate { get; private set; }
		#endregion

		#region Constructor
		public Card()
		{
			CardID = lastCardID++;
			ListingDate = DateTime.Now;
		}
		#endregion
	}
}
