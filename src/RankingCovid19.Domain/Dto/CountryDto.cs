using RankingCovid19.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace RankingCovid19.Domain.Dto
{
    public class CountryDto
    {
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public List<Covid19RankingDto> Rankings { get; set; }

        public CountryDto(Country country)
        {
            Id = country.Id;
            Name = country.Name;
            Rankings = country.Summaries.Select(c => new Covid19RankingDto(c)).ToList();
        }

        public static List<CountryDto> Convert(List<Country> countries) =>
            countries.Select(c => new CountryDto(c)).ToList();
    }
}
