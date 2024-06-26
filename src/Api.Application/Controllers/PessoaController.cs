﻿using Domain.Dtos;
using Domain.Dtos.PessoasDtos.PessoaDtos;
using Domain.Enuns.Pessoas;
using Domain.Interfaces.Services.Pessoas.Pessoa;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaServices _service;

        public PessoaController(IPessoaServices service)
        {
            _service = service;
        }


        [HttpGet("pessoas/{include}")]
        public async Task<ActionResult<ResponseDto<IEnumerable<PessoaDto>>>> GetAll(bool include = false)
        {
            try
            {
                var result = await _service.GetAll(include);
                if (result.Status)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseDto<IEnumerable<PessoaDto>>().Erro(ex));
            }
        }
        [HttpGet("pessoas/{include}/{idPessoa}/id")]
        public async Task<ActionResult<ResponseDto<IEnumerable<PessoaDto>>>> Get(Guid idPessoa, bool include = false)
        {
            try
            {
                var result = await _service.Get(idPessoa, include);
                if (result.Status)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseDto<IEnumerable<PessoaDto>>().Erro(ex));
            }
        }

        [HttpGet("pessoas/{include}/{pessoaTipo}/pessoa-tipo")]
        public async Task<ActionResult<ResponseDto<IEnumerable<PessoaDto>>>> GetAllByPessoaTipo(PessoaTipoEnum pessoaTipo, bool include = false)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            try
            {
                var result = await _service.GetAllByPessoaTipo(pessoaTipo, include);
                if (result.Status)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseDto<IEnumerable<PessoaDto>>().Erro(ex));
            }
        }
        [HttpPost("cadastrar")]
        public async Task<ActionResult<ResponseDto<IEnumerable<PessoaDto>>>> Create(PessoaDtoCreate pessoaDtoCreate)
        {
            try
            {
                var result = await _service.Create(pessoaDtoCreate);
                if (result.Status)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseDto<IEnumerable<PessoaDto>>().Erro(ex));
            }
        }
        [HttpPut("alterar")]
        public async Task<ActionResult<ResponseDto<IEnumerable<PessoaDto>>>> Update(PessoaDtoUpdate pessoaDtoCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Update(pessoaDtoCreate);
                if (result.Status)
                    return Ok(result);

                return BadRequest(result);
            }
            catch (Exception ex)
            {

                return BadRequest(new ResponseDto<IEnumerable<PessoaDto>>().Erro(ex));
            }
        }
    }
}
