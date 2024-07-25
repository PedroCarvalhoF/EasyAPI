using AutoMapper;
using Easy.Domain.Entities.Produto.CategoriaProduto;
using Easy.Domain.Intefaces;
using Easy.Services.CQRS.Produto.Categoria.Commands.Notifications;
using Easy.Services.DTOs;
using Easy.Services.DTOs.CategoriaProduto;
using MediatR;

namespace Easy.Services.CQRS.Produto.Categoria.Commands;

public class CategoriaProdutoCreateCommand : BaseCommands<CategoriaProdutoDtoView>
{
    public string DescricaoCategoria { get; private set; }
    public CategoriaProdutoCreateCommand(string descricaoCategoria)
    {
        DescricaoCategoria = descricaoCategoria;
    }


    public class CategoriaProdutoCreateCommandHandler : IRequestHandler<CategoriaProdutoCreateCommand, RequestResult<CategoriaProdutoDtoView>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CategoriaProdutoCreateCommandHandler(IUnitOfWork unitOfWork, IMediator mediator, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<RequestResult<CategoriaProdutoDtoView>> Handle(CategoriaProdutoCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var categoriaEntity = CategoriaProdutoEntity.Create(request.DescricaoCategoria, request.GetFiltro());
                if (!categoriaEntity.isBaseValida)
                    return RequestResult<CategoriaProdutoDtoView>.BadRequest("Entidade inválida.");

                await _unitOfWork.CategoriaProdutoBaseRepository.InsertAsync(categoriaEntity);
                var result = await _unitOfWork.CommitAsync();
                if (!result)
                {

                    return RequestResult<CategoriaProdutoDtoView>.BadRequest("Não foi possível cadastrar categoria do produto");
                }

                await _mediator.Publish(new CategoriaProdutoCreatedNotification(categoriaEntity));

                var categorioDto = _mapper.Map<CategoriaProdutoDtoView>(categoriaEntity);

                return RequestResult<CategoriaProdutoDtoView>.Ok(categorioDto, "Categoria criada com sucesso.");
            }
            catch (Exception ex)
            {

                return RequestResult<CategoriaProdutoDtoView>.BadRequest(ex.Message);
            }
        }



        //CategoriaProdutoRepository
        //public async Task<RequestResult> Handle(CategoriaProdutoCreateCommand request, CancellationToken cancellationToken)
        //{
        //    try
        //    {
        //        var categoriaEntity = CategoriaProdutoEntity.Create(request.DescricaoCategoria, request.FiltroBase);
        //        if (!categoriaEntity.isBaseValida)
        //            return new RequestResult().EntidadeInvalida();

        //        await _unitOfWork.CategoriaProdutoRepository.Create(categoriaEntity);
        //        var result = await _unitOfWork.CommitAsync();
        //        if (result)
        //        {
        //            await _mediator.Publish(new CategoriaProdutoCreatedNotification(categoriaEntity));
        //            return new RequestResult().Ok("Categoria de produto criada com sucesso.");
        //        }


        //        return new RequestResult().BadRequest("Não foi possível cadastrar cadastrar categoria");
        //    }
        //    catch (Exception ex)
        //    {

        //        return new RequestResult().BadRequest(ex.Message);
        //    }
        //}
    }
}
