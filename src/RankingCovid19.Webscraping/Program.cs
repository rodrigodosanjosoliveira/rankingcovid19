using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace RankingCovid19.Webscraping
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile(@"appsettings.json", false);
            var configuration = builder.Build();

            var seleniumConfigurations = new SeleniumConfigurations();
            new ConfigureFromConfigurationOptions<SeleniumConfigurations>(
                configuration.GetSection("SeleniumConfigurations"))
                    .Configure(seleniumConfigurations);

            var summaryPage = new SummaryPage(
                seleniumConfigurations);

            summaryPage.LoadPage();

            var summary = summaryPage.GetSummary();

            summaryPage.Close();
        }
    }
}
