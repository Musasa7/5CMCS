using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _5CMCS.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace _5CMCS.Data
{
	public class AppDbContext : DbContext
	{
		public DbSet<Claim> Claims => Set<Claim>();
		public DbSet<Lecturer> Lecturers => Set<Lecturer>();
		public DbSet<ApplicationUser> Users => Set<ApplicationUser>();

		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder b)
		{
			b.Entity<Lecturer>().HasKey(x => x.LecturerId);
			b.Entity<Claim>().HasKey(x => x.ClaimId);
			b.Entity<ApplicationUser>().HasKey(x => x.ApplicationUserId);

			b.Entity<Claim>()
				.HasOne(c => c.Lecturer)
				.WithMany(l => l.Claims)
				.HasForeignKey(c => c.LecturerId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
