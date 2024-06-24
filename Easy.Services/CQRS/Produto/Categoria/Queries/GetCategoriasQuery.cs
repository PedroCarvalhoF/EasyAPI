using Easy.Domain.Entities;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.Produto.Categoria.Queries;

public class GetCategoriasQuery : IRequest<RequestResult>
{
    FiltroBase FiltroBase { get; set; }
    public void SetFiltro(FiltroBase filtroBase)
      => FiltroBase = filtroBase;

    public class GetCategoriaQueryHandler : IRequestHandler<GetCategoriasQuery, RequestResult>
    {
        //FUTURAMENTE UTILIZAR DAPPER
        private readonly IUnitOfWork _unitOfWork;

        public GetCategoriaQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<RequestResult> Handle(GetCategoriasQuery request, CancellationToken cancellationToken)
        {
            var categorias = await _unitOfWork.CategoriaProdutoRepository.GetCategoriasProdutoAsync(request.FiltroBase);
            return new RequestResult().Ok(categorias);
        }
    }
}
