using Microsoft.Extensions.Configuration;
using System.IO;

namespace RankingCovid19.Webscraping
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json");
            var configuration = builder.Build();
        }
    }
}
