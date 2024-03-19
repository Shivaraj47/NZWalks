using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Model.Domain;

namespace NZWalks.API.Repository
{
	public class UserRepository : IUserRepository
	{
		private readonly NZWalkDbContext dbContext;

		public UserRepository(NZWalkDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public async Task<User> AuthenticateAsync(string username, string password)
		{
			var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Username == username && x.Password == password);

			if (user == null)
			{
				return null;
			}

			var userRole = await dbContext.User_Roles.Where(x => x.UserId == user.Id).ToListAsync();

			if (userRole.Any())
			{
				user.Roles = new List<string>();
				foreach (var roles1 in userRole)
				{
					var role = await dbContext.Roles.FirstOrDefaultAsync(x => x.Id == roles1.RoleId);
					if (role != null)
					{
						user.Roles.Add(role.Name);
					}
				}
			}

			user.Password = null;
			return user;
		}
	}
}
