using System;
using System.Runtime.Serialization;

namespace RankingCovid19.Domain.Dto
{
    [DataContract]
    public class CountryInputDto
    {
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Covid19RankingDto Summary { get; set; }
    }
}
