using Easy.Domain.Entities;
using Easy.Domain.Entities.Produto.CategoriaProduto;
using Easy.Domain.Intefaces;
using Easy.Services.CQRS.Produto.Categoria.Commands.Notifications;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.Produto.Categoria.Commands;

public class CategoriaProdutoCreateCommand : IRequest<RequestResult>
{
    public string DescricaoCategoria { get; private set; }
    FiltroBase FiltroBase { get; set; }
    public void SetFiltro(FiltroBase filtroBase)
      => FiltroBase = filtroBase;
    public CategoriaProdutoCreateCommand(string descricaoCategoria)
    {
        DescricaoCategoria = descricaoCategoria;
    }


    public class CategoriaProdutoCreateCommandHandler : IRequestHandler<CategoriaProdutoCreateCommand, RequestResult>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;

        public CategoriaProdutoCreateCommandHandler(IUnitOfWork unitOfWork, IMediator mediator)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

        public async Task<RequestResult> Handle(CategoriaProdutoCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var categoriaEntity = CategoriaProdutoEntity.Create(request.DescricaoCategoria, request.FiltroBase);
                if (!categoriaEntity.isBaseValida)
                    return new RequestResult().EntidadeInvalida();

                await _unitOfWork.CategoriaProdutoBaseRepository.InsertAsync(categoriaEntity);
                var result = await _unitOfWork.CommitAsync();
                if (result)
                {
                    await _mediator.Publish(new CategoriaProdutoCreatedNotification(categoriaEntity));
                    return new RequestResult().Ok("Categoria de produto criada com sucesso.");
                }


                return new RequestResult().BadRequest("Não foi possível cadastrar cadastrar categoria");
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
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
