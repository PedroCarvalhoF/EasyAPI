using Easy.Domain.Entities;
using Easy.Domain.Intefaces;
using Easy.Domain.Intefaces.Repository.Produto;
using Easy.Services.DTOs;
using Easy.Services.DTOs.Produto;
using Easy.Services.Tools.ImageUrls;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.Produto.Commands;

public class ProdutoUploadImageCommand : BaseCommands<ProdutoDto>
{
    public required ProdutoDtoUploadImageRequest RequiredUploadImageRequest { get; set; }

    public class ProdutoUpdatImageCommandHandler(IUtil _util, IUnitOfWork _repository, IProdutoDapperRepository<FiltroBase> _dapperRepository) : IRequestHandler<ProdutoUploadImageCommand, RequestResult<ProdutoDto>>
    {
        public async Task<RequestResult<ProdutoDto>> Handle(ProdutoUploadImageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.RequiredUploadImageRequest.IFormFile == null)
                {
                    return new RequestResult<ProdutoDto>().Erro("Arquivo não localizado.");
                }

                string _destino = "Produtos";
                var produto = await _repository.ProdutoBaseRepository.SelectAsync(request.RequiredUploadImageRequest.Produtoid, request.GetFiltro());

                if (produto == null)
                    return new RequestResult<ProdutoDto>().Erro("Produto não localizado.");

                if (request.RequiredUploadImageRequest.IFormFile != null && request.RequiredUploadImageRequest.IFormFile.Length > 0)
                {
                    // Excluir a imagem antiga, se houver
                    _util.DeleteImage(produto.ImagemUrl!, _destino);

                    // Salvar a nova imagem
                    produto.SetImageUrl(await _util.SaveImage(request.RequiredUploadImageRequest.IFormFile, _destino));
                }

                var userRetorno = await _repository.ProdutoBaseRepository.Update(produto);
                if (!await _repository.CommitAsync())
                    return new RequestResult<ProdutoDto>().ErroSalvarNoBanco();

                var produtoViewBDAlterado = await _dapperRepository.GetProdutoByIdAsync(request.GetFiltro(), request.RequiredUploadImageRequest.Produtoid);

                if (!produtoViewBDAlterado.Any())
                    return new RequestResult<ProdutoDto>().Erro("Erro inesperado.");

                var dto = DtoMapper.ParceProdutoDto(produtoViewBDAlterado.Single());

                return new RequestResult<ProdutoDto>().ResultOk(dto);
            }
            catch (Exception ex)
            {

                return new RequestResult<ProdutoDto>().Erro(ex);
            }
        }
    }
}
