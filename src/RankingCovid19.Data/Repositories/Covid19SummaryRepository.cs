using RankingCovid19.Data.Context;
using RankingCovid19.Domain.Contracts.Repositories;
using RankingCovid19.Domain.Entities;
using System.Linq;

namespace RankingCovid19.Data.Repositories
{
    public class Covid19SummaryRepository : Repository<Country>, ICountryRepository
    {
        public Covid19SummaryRepository(Covid19SummaryContext context)
            : base(context) { }

        public Country GetCountry(string name) => GetAll().FirstOrDefault(c => c.Name == name);

    }
}
