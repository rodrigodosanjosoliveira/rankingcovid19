using RankingCovid19.Domain.ValueTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace RankingCovid19.Domain.Dto
{
    [DataContract]
    public class Covid19RankingDto
    {
        [DataMember]
        public long ActiveCases { get; set; }
        [DataMember]
        public long RecoveredCases { get; set; }
        [DataMember]
        public long FatalCases { get; set; }
        [DataMember]
        public int RankingPosition { get; set; }

        public Guid CountryId { get; set; }

        public Covid19RankingDto(Covid19Ranking summary)
        {
            ActiveCases = summary.ActiveCases;
            RecoveredCases = summary.RecoveredCases;
            FatalCases = summary.FatalCases;
            RankingPosition = summary.RankingPosition;
        }

        public static List<Covid19RankingDto> Convert(List<Covid19Ranking> summaries) =>
            summaries.Select(summary => new Covid19RankingDto(summary)).ToList();
    }
}
