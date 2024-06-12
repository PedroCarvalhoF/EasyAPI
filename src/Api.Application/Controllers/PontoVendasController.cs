using Api.Domain.Dtos.PontoVendaDtos;
using Api.Domain.Interfaces.Services.PontoVenda;
using Api.Extensions;
using Domain.Dtos;
using Domain.Dtos.PontoVenda.Filtros;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PontoVendasController : ControllerBase
    {
        private readonly IPontoVendaService _service;

        public PontoVendasController(IPontoVendaService pontoVendaService)
        {
            _service = pontoVendaService;
        }


        [HttpGet("pdv/{idPdv}/dashboard-pdv/{include}")]
        public async Task<ActionResult> GetDashPdvById(Guid idPdv, bool include = true)
        {
            try
            {
                //necessário ser full includes para validar os calculos
                var respostaService = await _service.GetDashPdvById(idPdv, true);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<PontoVendaDto>>().Erro(ex));
            }
        }

        [HttpGet("pdv/{include}")]
        public async Task<ActionResult<ResponseDto<List<PontoVendaDto>>>> GetPdvs(bool include = false)
        {
            try
            {
                var respostaService = await _service.GetPdvs(include);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<PontoVendaDto>>().Erro(ex));
            }
        }

        [HttpGet("pdv/{id}/id/{include}")]
        public async Task<ActionResult<ResponseDto<List<PontoVendaDto>>>> GetByIdPdv(Guid id, bool include = false)
        {
            try
            {
                var respostaService = await _service.GetByIdPdv(id, include);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<PontoVendaDto>>().Erro(ex));
            }
        }
        [HttpGet("pdv/{IdPerfilUtilizarPDV}/IdPerfilUsuario/{include}")]
        public async Task<ActionResult<ResponseDto<List<PontoVendaDto>>>> GetByIdPerfilUsuario(Guid IdPerfilUtilizarPDV, bool include = false)
        {
            try
            {
                var respostaService = await _service.GetByIdPerfilUsuario(IdPerfilUtilizarPDV, include);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<PontoVendaDto>>().Erro(ex));
            }
        }
        [HttpGet("pdv/{abertoFechado}/AbertoFechado/{include}")]
        public async Task<ActionResult<ResponseDto<List<PontoVendaDto>>>> AbertosFechados(bool abertoFechado, bool include = false)
        {
            try
            {
                var respostaService = await _service.AbertosFechados(abertoFechado, include);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<PontoVendaDto>>().Erro(ex));
            }
        }

        [HttpPost("pdv/data/{include}")]
        public async Task<ActionResult<ResponseDto<List<PontoVendaDto>>>> FiltrarByData(PontoVendaDtoFiltrarData data, bool include = false)
        {
            try
            {
                var respostaService = await _service.FiltrarByData(data, include);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<PontoVendaDto>>().Erro(ex));
            }
        }

        [HttpPost("pdv/create/{include}")]
        public async Task<ActionResult<ResponseDto<List<PontoVendaDto>>>> Create(PontoVendaDtoCreate pontoVendaDtoCreate, bool include = false)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                pontoVendaDtoCreate.UserPdvCreateId = User.GetUserId();
                var respostaService = await _service.Create(pontoVendaDtoCreate, include);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<PontoVendaDto>>().Erro(ex));
            }
        }
        [HttpPut("pdv/{pontoVendaId}/encerrar/{include}")]
        public async Task<ActionResult<ResponseDto<List<PontoVendaDto>>>> Encerrar(Guid pontoVendaId, bool include = false)
        {
            try
            {
                var respostaService = await _service.Encerrar(pontoVendaId, include);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<PontoVendaDto>>().Erro(ex));
            }
        }

    }
}
