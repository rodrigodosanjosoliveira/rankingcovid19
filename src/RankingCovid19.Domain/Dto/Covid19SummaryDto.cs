using RankingCovid19.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace RankingCovid19.Domain.Dto
{
    [DataContract]
    public class Covid19SummaryDto
    {
        public Guid Id { get; set; }

        [DataMember]
        public string Country { get; set; }
        [DataMember]
        public long ActiveCases { get; set; }
        [DataMember]
        public long RecoveredCases { get; set; }
        [DataMember]
        public long FatalCases { get; set; }
        [DataMember]
        public long Total { get; set; }

        public Covid19SummaryDto(Covid19Summary summary)
        {
            Id = summary.Id;
            Country = summary.Country;
            ActiveCases = summary.ActiveCases;
            RecoveredCases = summary.RecoveredCases;
            FatalCases = summary.FatalCases;
            Total = summary.Total;
        }

        public static List<Covid19SummaryDto> Convert(List<Covid19Summary> summaries) =>
            summaries.Select(summary => new Covid19SummaryDto(summary)).ToList();
    }
}
