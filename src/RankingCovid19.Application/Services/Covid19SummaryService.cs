using RankingCovid19.Domain.Contracts.Repositories;
using RankingCovid19.Domain.Contracts.Services;
using RankingCovid19.Domain.Dto;
using RankingCovid19.Domain.Entities;
using System.Threading.Tasks;

namespace RankingCovid19.Application.Services
{
    public class Covid19SummaryService : ICovid19SummaryService
    {
        private readonly ICovid19SummaryRepository _covid19SummaryRepository;

        public Covid19SummaryService(ICovid19SummaryRepository covid19SummaryRepository)
        {
            _covid19SummaryRepository = covid19SummaryRepository;
        }

        public async Task<Covid19Summary> Create(Covid19SummaryInputDto covid19SummaryInputDto)
        {
            var summary = new Covid19Summary(covid19SummaryInputDto.Country, covid19SummaryInputDto.ActiveCases, covid19SummaryInputDto.RecoveredCases, covid19SummaryInputDto.FatalCases);

            return await _covid19SummaryRepository.Create(summary);
        }

        public async Task<Covid19Summary> GetCovid19Summary(string country) => await _covid19SummaryRepository.GetCovid19Summary(country);

        public async Task<Covid19Summary> Update(string country, Covid19SummaryDto covid19SummaryDto)
        {
            Covid19Summary summaryDb = await GetCovid19Summary(country);
            var updatedSummary = new Covid19Summary(covid19SummaryDto.Country, covid19SummaryDto.ActiveCases, covid19SummaryDto.RecoveredCases, covid19SummaryDto.FatalCases);
            return await _covid19SummaryRepository.Update(updatedSummary);
        }
    }
}
