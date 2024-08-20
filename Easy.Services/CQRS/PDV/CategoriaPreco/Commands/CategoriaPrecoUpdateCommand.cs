using AutoMapper;
using Easy.Domain.Entities.PDV.CategoriaPreco;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.CategoriaPreco;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.CategoriaPreco.Commands;

public class CategoriaPrecoUpdateCommand : BaseCommands<CategoriaPrecoDto>
{
    public required CategoriaPrecoDtoUpdate Categoria { get; set; }
    public class CategoriaPrecoUpdateCommandHandler(IUnitOfWork _repository) : IRequestHandler<CategoriaPrecoUpdateCommand, RequestResult<CategoriaPrecoDto>>
    {
        public async Task<RequestResult<CategoriaPrecoDto>> Handle(CategoriaPrecoUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var categoriaPrecoUpdateEntity = CategoriaPrecoEntity.Update(request.Categoria.Id, request.Categoria.Habilitado, request.Categoria.Codigo, request.Categoria.DescricaoCategoriaPreco, request.GetFiltro());

                if (!categoriaPrecoUpdateEntity.isBaseValida)
                    return RequestResult<CategoriaPrecoDto>.BadRequest();

                _repository.CategoriaPrecoRepository.UpdateAsync(categoriaPrecoUpdateEntity, request.GetFiltro());

                if (!await _repository.CommitAsync())
                    return RequestResult<CategoriaPrecoDto>.BadRequest();

                var dto = DtoMapper.ParceCategoriaPrecoDto(categoriaPrecoUpdateEntity);

                return RequestResult<CategoriaPrecoDto>.Ok(dto, "Categoria alterada com sucesso");

            }
            catch (Exception ex)
            {
                return RequestResult<CategoriaPrecoDto>.BadRequest(ex.Message);
            }
            finally
            {
                _repository.FinalizarContexto();
            }
        }
    }

}
