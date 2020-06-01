using RankingCovid19.Domain.Entities;

namespace RankingCovid19.Domain.Contracts.Repositories
{
    public interface ICountryRepository : IRepository<Country> 
    {
        Country GetCountry(string name);
    }
}
