using AutoMapper;
using Easy.Domain.Entities.Produto;
using Easy.Domain.Enuns;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.Produto;
using MediatR;

namespace Easy.Services.CQRS.Produto.Commands;

public class ProdutoCommandCreate : BaseCommands<ProdutoDtoView>
{
    public string NomeProduto { get; set; }
    public string Codigo { get; set; }
    public string? Descricao { get; set; }
    public string? Observacoes { get; set; }
    public string? ImagemUrl { get; set; }
    public Guid CategoriaProdutoEntityId { get; set; }
    public MedidaProdutoEnum MedidaProdutoEnum { get; set; }
    public ProdutoTipoEnum TipoProdutoEnum { get; set; }
    public class ProdutoCreateCommandHandler : IRequestHandler<ProdutoCommandCreate, RequestResult<ProdutoDtoView>>
    {
        private readonly IUnitOfWork _repository;
        private readonly IMapper _mapper;
        public ProdutoCreateCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            _repository = uow;
            _mapper = mapper;
        }

        public async Task<RequestResult<ProdutoDtoView>> Handle(ProdutoCommandCreate request, CancellationToken cancellationToken)
        {
            try
            {
                var produtoEntity = ProdutoEntity.Create(request.NomeProduto, request.Codigo, request.Descricao, request.Observacoes, request.ImagemUrl, request.CategoriaProdutoEntityId, request.MedidaProdutoEnum, request.TipoProdutoEnum, request.GetFiltro());

                await _repository.ProdutoRepository.InsertAsync(produtoEntity, request.GetFiltro());
                var resultCommit = await _repository.CommitAsync();

                if (resultCommit)
                    return RequestResult<ProdutoDtoView>.Ok(_mapper.Map<ProdutoDtoView>(produtoEntity));

                return RequestResult<ProdutoDtoView>.BadRequest("Não foi possível cadastrar produto.");
            }
            catch (Exception ex)
            {

                return RequestResult<ProdutoDtoView>.BadRequest(ex.Message);
            }
        }
    }

}
