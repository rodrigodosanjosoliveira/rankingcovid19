using RankingCovid19.Domain.Entities;
using System.Threading.Tasks;

namespace RankingCovid19.Domain.Contracts.Repositories
{
    public interface ICovid19SummaryRepository : IRepository<Covid19Summary> 
    {
        Task<Covid19Summary> GetCovid19Summary(string country);
    }
}
