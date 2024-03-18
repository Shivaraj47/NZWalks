using Microsoft.EntityFrameworkCore;
using NZWalks.API.Model.Domain;

namespace NZWalks.API.Data
{
	public class NZWalkDbContext : DbContext
	{
		public NZWalkDbContext(DbContextOptions<NZWalkDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User_Role>()
				 .HasOne(x => x.role)
				 .WithMany(x => x.UserRoles)
				 .HasForeignKey(x => x.RoleId);

			modelBuilder.Entity<User_Role>()
				 .HasOne(x => x.user)
				 .WithMany(x => x.UserRoles)
				 .HasForeignKey(x => x.UserId);
		}

		//create Dbset properties

		public DbSet<Region> regions
		{
			get; set;
		}
		public DbSet<Walk> walks
		{
			get; set;
		}

		public DbSet<WalkDifficulty> walkDifficulties
		{
			get; set;
		}

		public DbSet<User> Users
		{
			get; set;
		}
		public DbSet<Role> Roles
		{
			get; set;
		}
		public DbSet<User_Role> User_Roles
		{
			get; set;
		}
	}
}
