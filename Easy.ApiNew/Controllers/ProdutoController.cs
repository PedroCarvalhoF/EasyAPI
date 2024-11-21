using Easy.Api.Extensions;
using Easy.Api.Tools;
using Easy.Domain.Intefaces;
using Easy.Services.CQRS.Produto.Commands;
using Easy.Services.CQRS.Produto.Queries;
using Easy.Services.DTOs;
using Easy.Services.DTOs.Produto;
using Easy.Services.Tools.ImageUrls;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Easy.ApiNew.Controllers;

[Route("[controller]")]
[ApiController]
//[Authorize]
public class ProdutoController(IMediator _mediator) : ControllerBase
{

    [HttpPost("get-produto-filter")]
    public async Task<ActionResult<RequestResult<IEnumerable<ProdutoDto>>>> GetProdutosAynsc([FromBody] GetProdutosQueryCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<IEnumerable<ProdutoDto>>().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPost("cadastrar")]
    public async Task<ActionResult<RequestResult<ProdutoDto>>> CadastraProdutoAsync([FromBody] ProdutoCreateCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<ProdutoDto>().ParseToActionResult(await _mediator.Send(command));
    }

    [HttpPut("alterar")]
    public async Task<ActionResult<RequestResult<ProdutoDto>>> AlterarProdutoAsync([FromBody] ProdutoUpdateCommand command)
    {
        command.SetUsers(User.GetUserMasterUserDatalhes());
        return new ReturnActionResult<ProdutoDto>().ParseToActionResult(await _mediator.Send(command));
    }


    [HttpPost("upload-image-formdata/{idProduto}")]
    //via Form Data - aplicativos
    public async Task<ActionResult<RequestResult<ProdutoDtoImageResult>>> UploadImage([FromServices] IUtil _util, [FromServices] IUnitOfWork _repository, Guid idProduto)
    {
        try
        {
            if (!Request.HasFormContentType)
            {
                return RequestResult<ProdutoDtoImageResult>.BadRequest("Arquivo não localizado");
            }

            string _destino = "Produtos";
            var produto = await _repository.ProdutoBaseRepository.SelectAsync(idProduto, User.GetUserMasterUserDatalhes());
            if (produto == null) return NoContent();

            var file = Request.Form.Files[0];
            if (file.Length > 0)
            {
                _util.DeleteImage(produto.ImagemUrl!, _destino);
                produto.SetImageUrl(await _util.SaveImage(file, _destino));
            }

            var userRetorno = await _repository.ProdutoBaseRepository.Update(produto);
            await _repository.CommitAsync();

            return Ok(ProdutoDtoImageResult.ImagemAlteradaComSucesso(produto.Id));
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar realizar upload de Foto do Usuário. Erro: {ex.Message}");
        }
    }

    [HttpPost("upload-image/{idProduto}")]
    //via upload
    public async Task<ActionResult<RequestResult<ProdutoDtoImageResult>>> UploadImage([FromServices] IUtil _util, [FromServices] IUnitOfWork _repository, Guid idProduto, IFormFile imagemUpload)
    {
        try
        {
            if (imagemUpload == null)
            {
                return RequestResult<ProdutoDtoImageResult>.BadRequest("Arquivo não localizado");
            }

            string _destino = "Produtos";
            var produto = await _repository.ProdutoBaseRepository.SelectAsync(idProduto, User.GetUserMasterUserDatalhes());
            if (produto == null) return NoContent();

            if (imagemUpload != null && imagemUpload.Length > 0)
            {
                // Excluir a imagem antiga, se houver
                _util.DeleteImage(produto.ImagemUrl!, _destino);

                // Salvar a nova imagem
                produto.SetImageUrl(await _util.SaveImage(imagemUpload, _destino));
            }

            var userRetorno = await _repository.ProdutoBaseRepository.Update(produto);
            await _repository.CommitAsync();

            return Ok(ProdutoDtoImageResult.ImagemAlteradaComSucesso(produto.Id));
        }
        catch (Exception ex)
        {
            return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar realizar upload de Foto do Usuário. Erro: {ex.Message}");
        }
    }
}
