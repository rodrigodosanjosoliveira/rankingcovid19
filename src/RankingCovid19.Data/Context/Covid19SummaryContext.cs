using Microsoft.EntityFrameworkCore;
using RankingCovid19.Domain.Entities;
using RankingCovid19.Domain.ValueTypes;

namespace RankingCovid19.Data.Context
{
    public class Covid19SummaryContext: DbContext
    {
        public DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Covid19SummaryDb;User Id=sa;Password=Iso@9001");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Country>(
                p =>
                {
                    p.HasKey("Id");
                    p.Property(c => c.Name);
                });

            modelBuilder.Entity<Country>().OwnsMany<Covid19Ranking>("Summaries", t =>
            {
                t.WithOwner()
                    .HasForeignKey(ca => ca.CountryId)
                    .HasConstraintName("FK_Countries");
                t.Property(ca => ca.ActiveCases);
                t.Property(ca => ca.RecoveredCases);
                t.Property(ca => ca.FatalCases);
                t.Property(ca => ca.RankingPosition);
                t.HasKey("CountryId");
            });

        }
    }
}
