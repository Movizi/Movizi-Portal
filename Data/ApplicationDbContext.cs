using Microsoft.EntityFrameworkCore;
using Movizi_Portal.Models;

namespace Movizi_Portal.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		public DbSet<Project> Projects { get; set; }
		public DbSet<Service> Services { get; set; }
		public DbSet<ProjectService> ProjectServices { get; set; }
		public DbSet<Industry> Industries { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
