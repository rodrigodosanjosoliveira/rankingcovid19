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
        private readonly ICovid19SummaryService _covid19SummaryService;

        public SummaryController(ICovid19SummaryService covid19SummaryService)
        {
            _covid19SummaryService = covid19SummaryService;
        }

        [HttpGet("/{country}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Covid19SummaryDto>> Get(string country)
        {
            Error error;
            if (string.IsNullOrEmpty(country))
            {
                error = new Error
                {
                    Mensagem = "Parâmetro inválido",
                    StatusCode = "400"
                };
                return BadRequest(error);
            }

            var summary = await _covid19SummaryService.GetCovid19Summary(country);

            if (summary == null)
            {
                error = new Error
                {
                    Mensagem = "Sumário não encontrado",
                    StatusCode = "404"
                };
                return NotFound(error);
            }

            return Ok(new Covid19SummaryDto(summary));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Covid19SummaryDto>> Post([FromBody] string country)
        {
            if (string.IsNullOrEmpty(country))
                return BadRequest(new Error
                {
                    Mensagem = "Parâmetros inválidos",
                    StatusCode = "400"
                });


            return null;
        }
    }
}
