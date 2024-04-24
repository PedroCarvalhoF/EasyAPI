using Api.Domain.Dtos.PontoVendaDtos;
using Api.Domain.Interfaces.Services.PontoVenda;
using Domain.Dtos.PontoVendaDtos;
using Domain.ExceptionsPersonalizadas;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    class PontoVendasController : ControllerBase
    {
        private readonly IPontoVendaService pontoVendaService;

        public PontoVendasController(IPontoVendaService pontoVendaService)
        {
            this.pontoVendaService = pontoVendaService;
        }

        [HttpPost("gerar-novo-pdv")]
        public async Task<ActionResult> GerarPontoVenda([FromBody] PontoVendaDtoCreate pontoVendaDtoCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                PontoVendaDto result = await pontoVendaService.GerarPontoVenda(pontoVendaDtoCreate);
                if (result == null)
                    return BadRequest("Não foi possível realizar operação. Realize a depuração.ERRO CRÍTICO");
                return Ok(result);
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

        [HttpPut("encerrar-pdv/{pontoVendaId}")]
        public async Task<ActionResult> EncerrarPontoVenda(Guid pontoVendaId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                PontoVendaDto result = await pontoVendaService.EncerrarPontoVenda(pontoVendaId);
                if (result == null)
                    return BadRequest("Não foi possível realizar operação. Realize a depuração.ERRO CRÍTICO");
                return Ok(result);
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

        [HttpGet("consultar-pdv/{abertoFechado}")]
        public async Task<ActionResult> ConsultarPontoVenda(bool abertoFechado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                IEnumerable<PontoVendaDto> result = await pontoVendaService.ConsultarPontoVenda(abertoFechado);
                if (result == null)
                    return BadRequest("Não foi possível realizar operação.");
                return Ok(result);
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

        [HttpPost("consultar-pdvs-by-idsPdvs")]
        public async Task<ActionResult> ConsultarPdvsById([FromBody] List<Guid> idsPdvs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                IEnumerable<PontoVendaDto> pdvsDtos = await pontoVendaService.ConsultarPdvsById(idsPdvs);
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

        [HttpPost("consultar-pdv-data")]
        public async Task<ActionResult> ConsultarPontoVendaByData(PdvGetByData pdvGetByData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                IEnumerable<PontoVendaDto> result = await pontoVendaService.ConsultarPontoVendaByData(pdvGetByData);

                return Ok(result);
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











        //[HttpGet("consultar-detalhado-pdv/{pdvId}")]
        //public async Task<ActionResult> ConsultarPontoVenda(Guid pdvId)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    try
        //    {
        //        PontoVendaResumoDetalhadoDto result = await pontoVendaService.ConsultarPontoVenda(pdvId);
        //        if (result == null)
        //            return BadRequest("Não foi possível realizar operação.");
        //        return Ok(result);
        //    }
        //    catch (ModelsExceptions ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return this.StatusCode(StatusCodes.Status500InternalServerError,
        //            $"Erro.Detalhes: {ex.Message}");
        //    }
        //}

        //[HttpPost("consultar-pdvs")]
        //public async Task<ActionResult> ConsultarPdvsById([FromBody] List<Guid> idsPdvs)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    try
        //    {
        //        IEnumerable<PontoVendaResumoDiaDto> pdvsDtos = await pontoVendaService.ConsultarPdvsById(idsPdvs);
        //        if (pdvsDtos == null)
        //            return BadRequest("Não foi possível realizar operação.");
        //        return Ok(pdvsDtos);
        //    }
        //    catch (ModelsExceptions ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return this.StatusCode(StatusCodes.Status500InternalServerError,
        //            $"Erro.Detalhes: {ex.Message}");
        //    }
        //}

        //[HttpPost("consultar-pdvs-data")]
        //public async Task<ActionResult> ConsultarPdvsById([FromBody] FiltroConsultaPdvDashDto filtro)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    try
        //    {
        //        IEnumerable<PontoVendaResumoDiaDto> pdvsDtos = await pontoVendaService.InfoDashPdvsByPeriodo(filtro);
        //        if (pdvsDtos == null)
        //            return BadRequest("Não foi possível realizar operação.");
        //        return Ok(pdvsDtos);
        //    }
        //    catch (ModelsExceptions ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //    catch (Exception ex)
        //    {
        //        return this.StatusCode(StatusCodes.Status500InternalServerError,
        //            $"Erro.Detalhes: {ex.Message}");
        //    }
        //}
    }
}
