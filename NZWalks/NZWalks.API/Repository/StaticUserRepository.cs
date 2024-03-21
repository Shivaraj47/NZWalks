﻿
using NZWalks.API.Model.Domain;

namespace NZWalks.API.Repository
{
	public class StaticUserRepository : IUserRepository
	{
		private List<User> Users = new List<User>()
		{
			//new User()
			//{
			//    FirtName = "Read Only",
			//    LastName = "User",
			//    EmailAddress = "readonly@user.com",
			//    Id = Guid.NewGuid(),
			//    Username = "readonly@user.com",
			//    Password = "Readonly@user",
			//    Roles = new List<string> {"reader"}
			//},
			//new User()
			//{
			//    FirtName = "Read Write",
			//    LastName = "User",
			//    EmailAddress = "readwrite@user.com",
			//    Id = Guid.NewGuid(),
			//    Username = "readwrite@user.com",
			//    Password = "Readwrite@user",
			//    Roles = new List<string> {"reader","writer"}
			//}
		};

		public async Task<User> AuthenticateAsync(string username, string password)
		{
			var user = Users.Find(x => x.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase) && x.Password == password);

			return user;
		}
	}
}
