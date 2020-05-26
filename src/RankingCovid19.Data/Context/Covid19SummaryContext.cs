using Microsoft.EntityFrameworkCore;
using RankingCovid19.Domain.Entities;

namespace RankingCovid19.Data.Context
{
    public class Covid19SummaryContext: DbContext
    {
        public DbSet<Covid19Summary> Covid19Summary { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Covid19SummaryDb;User Id=sa;Password=Iso@9001");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Covid19Summary>(
                p =>
                {
                    p.HasKey("Id");
                    p.Property(e => e.Country);
                    p.Property(e => e.ActiveCases);
                    p.Property(e => e.RecoveredCases);
                    p.Property(e => e.FatalCases);
                }
            );

        }
    }
}
