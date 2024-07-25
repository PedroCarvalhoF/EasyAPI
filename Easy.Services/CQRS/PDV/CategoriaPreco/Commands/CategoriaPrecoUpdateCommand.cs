using AutoMapper;
using Easy.Domain.Entities.PDV.CategoriaPreco;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.CategoriaPreco;
using MediatR;

namespace Easy.Services.CQRS.PDV.CategoriaPreco.Commands;

public class CategoriaPrecoUpdateCommand : BaseCommands<CategoriaPrecoDtoView>
{
    public required CategoriaPrecoDtoUpdate Categoria { get; set; }
    public class CategoriaPrecoUpdateCommandHandler(IUnitOfWork _repository, IMapper _mapper) : IRequestHandler<CategoriaPrecoUpdateCommand, RequestResult<CategoriaPrecoDtoView>>
    {
        public async Task<RequestResult<CategoriaPrecoDtoView>> Handle(CategoriaPrecoUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var categoriaPrecoUpdateEntity = CategoriaPrecoEntity.Update(request.Categoria.Id, request.Categoria.Habilitado, request.Categoria.Codigo, request.Categoria.DescricaoCategoriaPreco, request.GetFiltro());

                if (!categoriaPrecoUpdateEntity.isBaseValida)
                    return RequestResult<CategoriaPrecoDtoView>.BadRequest();

                await _repository.CategoriaPrecoRepository.UpdateAsync(categoriaPrecoUpdateEntity, request.GetFiltro());

                if (!await _repository.CommitAsync())
                    return RequestResult<CategoriaPrecoDtoView>.BadRequest();

                var dto = _mapper.Map<CategoriaPrecoDtoView>(categoriaPrecoUpdateEntity);

                return RequestResult<CategoriaPrecoDtoView>.Ok(dto, "Categoria alterada com sucesso");

            }
            catch (Exception ex)
            {
                return RequestResult<CategoriaPrecoDtoView>.BadRequest(ex.Message);
            }
        }
    }

}
