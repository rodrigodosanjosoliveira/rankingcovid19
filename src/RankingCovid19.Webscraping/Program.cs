using Flurl.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RankingCovid19.Domain.Entities;
using System.IO;
using System.Threading.Tasks;

namespace RankingCovid19.Webscraping
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            var seleniumConfigurations = new SeleniumConfigurations();
            new ConfigureFromConfigurationOptions<SeleniumConfigurations>(
                configuration.GetSection("SeleniumConfigurations"))
                    .Configure(seleniumConfigurations);

            var summaryPage = new SummaryPage(seleniumConfigurations);
            var summary = summaryPage.GetSummary("brazil");

            var api = new ServiceApi();
            new ConfigureFromConfigurationOptions<ServiceApi>(
                configuration.GetSection("ServiceApi"))
                .Configure(api);

            await SaveSummaryAsync(summary, api).ConfigureAwait(false);
            summaryPage.Close();
        }

        private static async Task SaveSummaryAsync(Covid19Summary summary, ServiceApi api)
        {
            await api.Endpoint.PostJsonAsync(summary);
        }
    }
}
