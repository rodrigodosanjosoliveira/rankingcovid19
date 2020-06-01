using Microsoft.Extensions.DependencyInjection;
using RankingCovid19.Crosscuting.IoC;
using System;

namespace RankingCovid19.Webscraping.Configuration
{
    public static class DependencyInjectionSetup
    {
        public static void AddDependencyInjectionSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
