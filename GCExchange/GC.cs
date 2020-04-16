using System;
using System.Collections.Generic;
using System.Text;

namespace GCExchange
{
	static class GC
	{
		/// <summary>
		/// Create a user account in the Gift Card Xchange App
		/// </summary>
		/// <param name="userName">Name of the user</param>
		/// <param name="emailAddress">Email address of the user</param>
		/// <param name="userType">Type of user</param>
		/// <returns></returns>
		public static User Register(string userName,
									string emailAddress,
									TypeOfUser userType)
		{
			var user = new User
			{
				UserName = userName,
				EmailAddress = emailAddress,
				UserType = userType
			};
			return user;
		}
	}
}