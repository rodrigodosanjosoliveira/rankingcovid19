using Microsoft.Extensions.DependencyInjection;
using RankingCovid19.Application.Services;
using RankingCovid19.Data.Context;
using RankingCovid19.Data.Repositories;
using RankingCovid19.Domain.Contracts.Repositories;
using RankingCovid19.Domain.Contracts.Services;

namespace RankingCovid19.Crosscuting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddTransient<ICovid19RankingService, Covid19RankingService>();
            services.AddTransient<ICountryRepository, Covid19SummaryRepository>();
            services.AddScoped<Covid19SummaryContext>();
        }
    }
}
