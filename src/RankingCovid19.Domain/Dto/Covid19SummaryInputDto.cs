using System;
using System.Runtime.Serialization;

namespace RankingCovid19.Domain.Dto
{
    [DataContract]
    public class Covid19SummaryInputDto
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
    }
}
