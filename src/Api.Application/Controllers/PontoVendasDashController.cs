using Api.Domain.Interfaces.Services.PontoVenda;
using Domain.Dtos.PedidoDtos;
using Domain.ExceptionsPersonalizadas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    class PontoVendasDashController : Controller
    {
        private readonly IPontoVendaService _pontoVendaService;

        public PontoVendasDashController(IPontoVendaService pontoVendaService)
        {
            this._pontoVendaService = pontoVendaService;
        }

        [HttpPost("dash-pdvs-by-idsPdvs")]
        public async Task<ActionResult<DashPontoVendaDtosV2>> DashPdvsByIdPDVs([FromBody] List<Guid> idsPdvs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                DashPontoVendaDtosV2 pdvsDtos = await _pontoVendaService.DashPdvsByIdsPdvs(idsPdvs);
                //pdvsDtos.all_pedidos = null;
                //pdvsDtos.all_pedidos_cancelados = null;
                //pdvsDtos.all_validos = null;
                if (pdvsDtos == null)
                    return BadRequest("Não foi possível realizar operação.");
                return Ok(pdvsDtos);
            }
            catch (ModelsExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro.Detalhes: {ex.Message}");
            }
        }
    }
}
