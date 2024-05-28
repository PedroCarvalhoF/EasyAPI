using Domain.Dtos;
using Domain.Dtos.Cotacoes.TaxasCDISELIC;
using Domain.Interfaces.Services.HGApis;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class HGApis : ControllerBase
    {
        private readonly ITaxasCDISelicService? _taxasCDISelicService;

        public HGApis(ITaxasCDISelicService? taxasCDISelicService)
        {
            _taxasCDISelicService = taxasCDISelicService;
        }

        [HttpGet("taxas-cdi-selic")]
        public async Task<ActionResult<ResponseDto<List<TaxasDtosHGBrasil>>>> GetTaxas()
        {
            try
            {
                var result = await _taxasCDISelicService.GetTaxas();

                if (!result.Status)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<TaxasDtosHGBrasil>>().Erro(ex));
            }
        }
    }
}
