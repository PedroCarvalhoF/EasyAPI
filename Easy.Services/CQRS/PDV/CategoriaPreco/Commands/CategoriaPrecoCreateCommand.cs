using Easy.Domain.Entities.PDV.CategoriaPreco;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.CategoriaPreco;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.CategoriaPreco.Commands;
public class CategoriaPrecoCreateCommand : BaseCommands<CategoriaPrecoDto>
{
    public required CategoriaPrecoDtoCreate CategoriaPreco { get; set; }

    public class CategoriaPrecoCreateCommandHandler(IUnitOfWork _repository) : IRequestHandler<CategoriaPrecoCreateCommand, RequestResult<CategoriaPrecoDto>>
    {
        public async Task<RequestResult<CategoriaPrecoDto>> Handle(CategoriaPrecoCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var filtro = request.GetFiltro();

                var categoriaPreco = CategoriaPrecoEntity.Create(request.CategoriaPreco.Codigo, request.CategoriaPreco.DescricaoCategoriaPreco, request.GetFiltro());

                if (!categoriaPreco.isBaseValida)
                    return RequestResult<CategoriaPrecoDto>.BadRequest();

                var codigoExist = await _repository.CategoriaPrecoRepository.GetByCodigoAsync(categoriaPreco.Codigo, filtro);
                if (codigoExist.Id != Guid.Empty)
                    return RequestResult<CategoriaPrecoDto>.BadRequest("Código já está em uso.");

                var descricaoExist = await _repository.CategoriaPrecoRepository.GetByDescricaoCategoriaAsync(categoriaPreco.DescricaoCategoriaPreco, filtro);
                if (descricaoExist.Id != Guid.Empty)
                    return RequestResult<CategoriaPrecoDto>.BadRequest("Descrição já está em uso.");

                await _repository.CategoriaPrecoRepository.InsertAsync(categoriaPreco, request.GetFiltro());
                if (!await _repository.CommitAsync())
                    return RequestResult<CategoriaPrecoDto>.BadRequest();


                var categoriaPrecoCreate = await _repository.CategoriaPrecoRepository.GetByIdAsync(categoriaPreco.Id, filtro);

                var dto = DtoMapper.ParceCategoriaPrecoDto(categoriaPrecoCreate);
                
                return RequestResult<CategoriaPrecoDto>.Ok(dto);
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
