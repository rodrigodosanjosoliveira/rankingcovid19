using RankingCovid19.Domain.Contracts.Repositories;
using RankingCovid19.Domain.Contracts.Services;
using RankingCovid19.Domain.Dto;
using RankingCovid19.Domain.Entities;
using RankingCovid19.Domain.ValueTypes;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RankingCovid19.Application.Services
{
    public class Covid19RankingService : ICovid19RankingService
    {
        private readonly ICountryRepository _covid19RankingRepository;

        public Covid19RankingService(ICountryRepository covid19RankingRepository)
        {
            _covid19RankingRepository = covid19RankingRepository;
        }

        public async Task<Country> Create(CountryInputDto countryInputDto)
        {
            var newCountry = new Country(countryInputDto.Name,
                new List<Covid19Ranking>
                {
                    new Covid19Ranking(countryInputDto.Summary.ActiveCases,
                countryInputDto.Summary.RecoveredCases, countryInputDto.Summary.FatalCases, countryInputDto.Summary.RankingPosition)
                });

            return await _covid19RankingRepository.Create(newCountry);
        }

        public IEnumerable<Country> GetAll()
        {
            return _covid19RankingRepository.GetAll().ToList();
        }

        public Country GetCountry(string name) => _covid19RankingRepository.GetCountry(name);

        public async  Task<Country> Update(CountryInputDto countryInputDto)
        {
            return await _covid19RankingRepository.Update(new Country(countryInputDto.Name,
                                            new List<Covid19Ranking> { new Covid19Ranking(
                                                countryInputDto.Summary.ActiveCases,
                                                countryInputDto.Summary.RecoveredCases,
                                                countryInputDto.Summary.FatalCases,
                                                countryInputDto.Summary.RankingPosition)}));
        }
    }
}
