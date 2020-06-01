using System;
using System.Collections.Generic;

namespace RankingCovid19.Domain.ValueTypes
{
    public class Covid19Ranking : ValueObject
    {
        public Covid19Ranking() { }

        public Covid19Ranking(long activeCases, long recoveredCases, long fatalCases, int rankingPosition)
        {
            ActiveCases = activeCases;
            RecoveredCases = recoveredCases;
            FatalCases = fatalCases;
            RankingPosition = rankingPosition;
        }

        public long ActiveCases { get; }
        public long RecoveredCases { get; }
        public long FatalCases { get; }
        public int RankingPosition { get; }
        public Guid CountryId { get; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return ActiveCases;
            yield return RecoveredCases;
            yield return FatalCases;
            yield return RankingPosition;
            yield return CountryId;
        }
    }
}
