using System;
using System.Collections.Generic;
using System.Text;

namespace RankingCovid19.Domain.Entities
{
    public class Covid19Summary : Entity
    {
        public Covid19Summary() { }

        public Covid19Summary(string country, long activeCases, long recoveredCases, long fatalCases)
        {
            Country = country;
            ActiveCases = activeCases;
            RecoveredCases = recoveredCases;
            FatalCases = fatalCases;
        }

        public string Country { get;}
        public long ActiveCases { get; }
        public long RecoveredCases { get; }
        public long FatalCases { get; }

        public long Total => ActiveCases + RecoveredCases + FatalCases;
    }
}
