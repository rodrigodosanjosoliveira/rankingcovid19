using RankingCovid19.Domain.ValueTypes;
using System.Collections.Generic;

namespace RankingCovid19.Domain.Entities
{
    public class Country : Entity
    {
        public Country() { }
        public Country(string name, List<Covid19Ranking> summaries)
        {
            Name = name;
            Summaries = summaries;
        }
        public string Name { get; }
        public List<Covid19Ranking> Summaries { get; }
        public void AddRanking(Covid19Ranking ranking)
        {
            Summaries.Add(ranking);
        }
    }
}
