using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RankingCovid19.Domain.Contracts.Services;
using RankingCovid19.Domain.Dto;
using RankingCovid19.Domain.ValueTypes;
using System.Net.Mime;
using System.Threading.Tasks;

namespace RankingCovid19.Api.Controllers
{
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [ApiController]
    public class SummaryController : ControllerBase
    {
        private readonly ICovid19RankingService _covid19RankingService;

        public SummaryController(ICovid19RankingService covid19RankingService)
        {
            _covid19RankingService = covid19RankingService;
        }

        [HttpGet("/{country}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Covid19RankingDto> Get(string country)
        {
            Error error;

            var summary = _covid19RankingService.GetCountry(country);
            if(summary != null)
                return Ok(new CountryDto(summary));
            error = new Error
            {
                Mensagem = "Sumário não encontrado",
                StatusCode = "404"
            };

            return NotFound(error);

        }
    }
}
