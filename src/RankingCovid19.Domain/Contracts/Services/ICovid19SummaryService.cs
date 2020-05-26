using RankingCovid19.Domain.Dto;
using RankingCovid19.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace RankingCovid19.Domain.Contracts.Services
{
    public interface ICovid19SummaryService
    {
        Task<Covid19Summary> Create(Covid19SummaryInputDto covid19SummaryInputDto);

        Task<Covid19Summary> GetCovid19Summary(string country);

        Task<Covid19Summary> Update(string country, Covid19SummaryDto covid19SummaryDto);
    }
}
