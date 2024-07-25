using AutoMapper;
using Easy.Domain.Entities.PDV.CategoriaPreco;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.CategoriaPreco;
using MediatR;

namespace Easy.Services.CQRS.PDV.CategoriaPreco.Commands;
public class CategoriaPrecoCreateCommand : BaseCommands<CategoriaPrecoDtoView>
{
    public required CategoriaPrecoDtoCreate CategoriaPreco { get; set; }

    public class CategoriaPrecoCreateCommandHandler(IUnitOfWork _repository, IMapper _mapper) : IRequestHandler<CategoriaPrecoCreateCommand, RequestResult<CategoriaPrecoDtoView>>
    {
        public async Task<RequestResult<CategoriaPrecoDtoView>> Handle(CategoriaPrecoCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var categoriaPreco = CategoriaPrecoEntity.Create(request.CategoriaPreco.Codigo, request.CategoriaPreco.DescricaoCategoriaPreco, request.GetFiltro());

                if (!categoriaPreco.isBaseValida)
                    return RequestResult<CategoriaPrecoDtoView>.BadRequest();

                await _repository.CategoriaPrecoRepository.InsertAsync(categoriaPreco, request.GetFiltro());
                if (!await _repository.CommitAsync())
                    return RequestResult<CategoriaPrecoDtoView>.BadRequest();

                var dto = _mapper.Map<CategoriaPrecoDtoView>(categoriaPreco);

                return RequestResult<CategoriaPrecoDtoView>.Ok(dto);
            }
            catch (Exception ex)
            {

                return RequestResult<CategoriaPrecoDtoView>.BadRequest(ex.Message);
            }
        }
    }
}
