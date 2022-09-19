namespace Sat.Recruitment.Api.DataAccess
{
    using System;
    using Microsoft.EntityFrameworkCore;
    using Sat.Recruitment.Api.Models;

    public class RecruitmentContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public RecruitmentContext(DbContextOptions<RecruitmentContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .Property(p => p.UserType)
                .HasConversion(
                    v => v.ToString(),
                    v => (UserType)Enum.Parse(typeof(UserType), v));
        }
    }
}
