using Domain.Dtos;
using Domain.Dtos.Pessoas.DadosBancarios;
using Domain.Dtos.Pessoas.Endereco;
using Domain.Dtos.ViaCEP;
using Domain.Interfaces.Services.Pessoas.Endereco;
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
        private readonly IEnderecoServices _enderecoServices;

        public EnderecosController(IViaCepService viacep, IEnderecoServices enderecoServices)
        {
            _viaCepService = viacep;
            _enderecoServices = enderecoServices;
        }

        [HttpGet("endereco/{cep}/busca-cep")]
        public async Task<ActionResult<ResponseDto<List<ViaCEPDto>>>> BuscaCEP(string cep)
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

        [HttpGet("endereco/{include}/get-all")]
        public async Task<ActionResult<ResponseDto<List<EnderecoDto>>>> GetAll(bool include)
        {
            try
            {
                var respostaService = await _enderecoServices.GetAll(include);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<EnderecoDto>>().Erro(ex));
            }
        }

        [HttpPost("endereco/create")]
        public async Task<ActionResult<ResponseDto<List<EnderecoDto>>>> Create(EnderecoDtoCreate create)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var respostaService = await _enderecoServices.Create(create);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<EnderecoDto>>().Erro(ex));
            }
        }

        [HttpPut("endereco/update")]
        public async Task<ActionResult<ResponseDto<List<EnderecoDto>>>> Update(EnderecoDtoUpdate update)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var respostaService = await _enderecoServices.Update(update);

                if (respostaService.Status)
                    return Ok(respostaService);
                else
                    return BadRequest(respostaService);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto<List<EnderecoDto>>().Erro(ex));
            }
        }
    }
}