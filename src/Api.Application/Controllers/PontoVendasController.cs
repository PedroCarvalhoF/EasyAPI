using Api.Domain.Dtos.PontoVendaDtos;
using Api.Domain.Interfaces.Services.PontoVenda;
using Api.Extensions;
using Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        /// <summary>
        /// Consulta PDV abertos e fechados
        /// </summary>
        /// <returns></returns>

       
        public async Task<ActionResult<ResponseDto<List<PontoVendaDto>>>> GetPdvs()
        {
            ResponseDto<List<PontoVendaDto>> resposta = new ResponseDto<List<PontoVendaDto>>();
            resposta.Dados = new List<PontoVendaDto>();

            try
            {
                return await _service.GetPdvs();
            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";

                return resposta;
            }
        }
        [HttpGet("pdv/{id}/id")]
        public async Task<ActionResult<ResponseDto<List<PontoVendaDto>>>> GetByIdPdv(Guid id)
        {
            ResponseDto<List<PontoVendaDto>> resposta = new ResponseDto<List<PontoVendaDto>>();
            resposta.Dados = new List<PontoVendaDto>();

            try
            {
                return await _service.GetByIdPdv(id);
            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";

                return resposta;
            }
        }
        [HttpGet("pdv/{IdPerfilUtilizarPDV}/IdPerfilUsuario")]
        public async Task<ActionResult<ResponseDto<List<PontoVendaDto>>>> GetByIdPerfilUsuario(Guid IdPerfilUtilizarPDV)
        {
            ResponseDto<List<PontoVendaDto>> resposta = new ResponseDto<List<PontoVendaDto>>();
            resposta.Dados = new List<PontoVendaDto>();

            try
            {
                return await _service.GetByIdPerfilUsuario(IdPerfilUtilizarPDV);
            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";

                return resposta;
            }
        }
        [HttpGet("pdv/{abertoFechado}/AbertoFechado")]
        public async Task<ActionResult<ResponseDto<List<PontoVendaDto>>>> AbertosFechados(bool abertoFechado)
        {
            ResponseDto<List<PontoVendaDto>> resposta = new ResponseDto<List<PontoVendaDto>>();
            resposta.Dados = new List<PontoVendaDto>();

            try
            {
                return await _service.AbertosFechados(abertoFechado);
            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";

                return resposta;
            }
        }
        [HttpPost("pdv/create")]
        public async Task<ActionResult<ResponseDto<List<PontoVendaDto>>>> Create(PontoVendaDtoCreate pontoVendaDtoCreate)
        {
            ResponseDto<List<PontoVendaDto>> resposta = new ResponseDto<List<PontoVendaDto>>();
            resposta.Dados = new List<PontoVendaDto>();

            try
            {
                pontoVendaDtoCreate.IdPerfilAbriuPDV = User.GetUserId();
                return await _service.Create(pontoVendaDtoCreate);
            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";

                return resposta;
            }
        }
        [HttpPut("pdv/{pontoVendaId}/encerrar")]
        public async Task<ActionResult<ResponseDto<List<PontoVendaDto>>>> Encerrar(Guid pontoVendaId)
        {
            ResponseDto<List<PontoVendaDto>> resposta = new ResponseDto<List<PontoVendaDto>>();
            resposta.Dados = new List<PontoVendaDto>();

            try
            {
                return await _service.Encerrar(pontoVendaId);
            }
            catch (Exception ex)
            {
                resposta.Status = false;
                resposta.Mensagem = $"Erro.Detalhes: {ex.Message}";

                return resposta;
            }
        }
    }
}
