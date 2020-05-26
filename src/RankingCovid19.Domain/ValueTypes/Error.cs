using System.Collections.Generic;

namespace RankingCovid19.Domain.ValueTypes
{
    public class Error : ValueObject
    {
        public Error() { }

        public string StatusCode { get; set; }
        public string Mensagem { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return StatusCode;
            yield return Mensagem;
        }
    }
}
