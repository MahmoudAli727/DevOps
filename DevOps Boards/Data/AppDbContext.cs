using DevOps_Boards.Data.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DevOps_Boards.Data
{
	public class AppDbContext : IdentityDbContext<AppUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}
		public DbSet<Card> cards { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<IdentityRole>().HasData(
			   new IdentityRole
			   {
				   Id = Guid.NewGuid().ToString(),
				   Name = "User",
				   NormalizedName = "USER"
			   },
			   new IdentityRole
			   {
				   Id = Guid.NewGuid().ToString(),
				   Name = "TeamLeader",
				   NormalizedName = "TEAMLEADER"
			   }
		   );

		}
	}
}
