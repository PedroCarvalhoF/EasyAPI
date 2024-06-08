using Domain.Dtos;
using Domain.Dtos.Pessoas.DadosBancarios;
using Domain.Dtos.ViaCEP;
using Domain.Interfaces.Services.Pessoas.Pessoa;
using Domain.Interfaces.Services.ViaCEP;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EnderecosController : ControllerBase
    {
        private readonly IViaCepService _viaCepService;

        public EnderecosController(IViaCepService viacep)
        {
            _viaCepService = viacep;
        }

        [HttpGet("endereco/{cep}")]
        public async Task<ActionResult<ResponseDto<List<ViaCEPDto>>>> GetAll(string cep)
        {
            try
            {
                var respostaService = await _viaCepService.BuscarCEP(cep);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<DadosBancariosDto>>().Erro(ex));
            }
        }
    }
}