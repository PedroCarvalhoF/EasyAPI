using Api.Domain.Dtos.PontoVendaDtos;
using Api.Domain.Interfaces.Services.PontoVenda;
using Api.Extensions;
using Domain.Dtos;
using Domain.Dtos.PontoVenda.Filtros;
using Domain.Dtos.PontoVendaUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PontoVendasController : ControllerBase
    {
        private readonly IPontoVendaService _service;

        public PontoVendasController(IPontoVendaService pontoVendaService)
        {
            _service = pontoVendaService;
        }

        [HttpGet("pdv")]
        public async Task<ActionResult<ResponseDto<List<PontoVendaDto>>>> GetPdvs()
        {
            try
            {
                var respostaService = await _service.GetPdvs();

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
        [HttpGet("pdv/{id}/id")]
        public async Task<ActionResult<ResponseDto<List<PontoVendaDto>>>> GetByIdPdv(Guid id)
        {
            try
            {
                var respostaService = await _service.GetByIdPdv(id);

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
        [HttpGet("pdv/{IdPerfilUtilizarPDV}/IdPerfilUsuario")]
        public async Task<ActionResult<ResponseDto<List<PontoVendaDto>>>> GetByIdPerfilUsuario(Guid IdPerfilUtilizarPDV)
        {
            try
            {
                var respostaService = await _service.GetByIdPerfilUsuario(IdPerfilUtilizarPDV);

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
        [HttpGet("pdv/{abertoFechado}/AbertoFechado")]
        public async Task<ActionResult<ResponseDto<List<PontoVendaDto>>>> AbertosFechados(bool abertoFechado)
        {
            try
            {
                var respostaService = await _service.AbertosFechados(abertoFechado);

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

        [HttpPost("pdv/data")]
        public async Task<ActionResult<ResponseDto<List<PontoVendaDto>>>> FiltrarByData([FromBody] PontoVendaDtoFiltrarData data)
        {
            try
            {
                var respostaService = await _service.FiltrarByData(data);

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

        [HttpPost("pdv/create")]
        public async Task<ActionResult<ResponseDto<List<PontoVendaDto>>>> Create(PontoVendaDtoCreate pontoVendaDtoCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                pontoVendaDtoCreate.UserPdvCreateId = User.GetUserId();
                var respostaService = await _service.Create(pontoVendaDtoCreate);

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
        [HttpPut("pdv/{pontoVendaId}/encerrar")]
        public async Task<ActionResult<ResponseDto<List<PontoVendaDto>>>> Encerrar(Guid pontoVendaId)
        {
            try
            {
                var respostaService = await _service.Encerrar(pontoVendaId);

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
