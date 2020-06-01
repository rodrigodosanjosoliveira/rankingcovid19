using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.IO;
using Serilog;
using System;
using Microsoft.Extensions.DependencyInjection;
using RankingCovid19.Domain.Contracts.Services;
using RankingCovid19.Webscraping.Configuration;

namespace RankingCovid19.Webscraping
{
    public class Program
    {
        public static async System.Threading.Tasks.Task Main(string[] args)
        {
            var collection = new ServiceCollection();
            collection.AddDependencyInjectionSetup();

            var serviceProvider = collection.BuildServiceProvider();
            var covid19RankingService = serviceProvider.GetService<ICovid19RankingService>();

            var log = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            log.Information("Selenium configuration starting...");
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            var configuration = builder.Build();

            var seleniumConfigurations = new SeleniumConfigurations();
            new ConfigureFromConfigurationOptions<SeleniumConfigurations>(
                configuration.GetSection("SeleniumConfigurations"))
                    .Configure(seleniumConfigurations);
            log.Information("Selenium configuration loaded");

            log.Information("Starting ranking page");
            var rankingPage = new RankingPage(seleniumConfigurations);

            log.Information("Load ranking page via selenium");
            rankingPage.LoadPage();

            log.Information("Retrieve ranking data from http://www.bing.com/covid");
            var summaries = rankingPage.LoadRanking();

            log.Information("Saving ranking in database");
            foreach(var summary in summaries)
            {
                await covid19RankingService.Create(summary);
            }
            
            if (serviceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }

            log.Information("Closing and releasing driver´s resources");
            rankingPage.Close();

            Log.CloseAndFlush();
        }
    }
}
