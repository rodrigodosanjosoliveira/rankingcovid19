using RankingCovid19.Domain.Dto;
using RankingCovid19.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RankingCovid19.Domain.Contracts.Services
{
    public interface ICovid19RankingService
    {
        IEnumerable<Country> GetAll();
        Task<Country> Create(CountryInputDto countryInputDto);
        Country GetCountry(string name);
        Task<Country> Update(CountryInputDto countryInputDto);
    }


}
