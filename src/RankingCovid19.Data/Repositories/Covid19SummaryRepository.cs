using Microsoft.EntityFrameworkCore;
using RankingCovid19.Data.Context;
using RankingCovid19.Domain.Contracts.Repositories;
using RankingCovid19.Domain.Entities;
using System.Threading.Tasks;

namespace RankingCovid19.Data.Repositories
{
    public class Covid19SummaryRepository : Repository<Covid19Summary>, ICovid19SummaryRepository
    {
        public Covid19SummaryRepository(Covid19SummaryContext context)
            : base(context) { }

        public async Task<Covid19Summary> GetCovid19Summary(string country) => await GetAll().FirstOrDefaultAsync(s => s.Country.Equals(country));
    }
}
