using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.CategoriaPreco;
using Easy.Services.DTOs.CategoriaPreco.Request;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.CategoriaPreco.Queries;

public class GetCategoriaPrecoByIdQuery : BaseCommands<CategoriaPrecoDto>
{
    public required CategoriaPrecoRequestId CategoriaPrecoRequestId { get; set; }
    public class GetCategoriaPrecoByIdQueryHandler(IUnitOfWork _repository) : IRequestHandler<GetCategoriaPrecoByIdQuery, RequestResult<CategoriaPrecoDto>>
    {
        public async Task<RequestResult<CategoriaPrecoDto>> Handle(GetCategoriaPrecoByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var categoriaPrecoEntity = await _repository.CategoriaPrecoRepository.GetByIdAsync(request.CategoriaPrecoRequestId.IdCategoriaPreco, request.GetFiltro());

                if (categoriaPrecoEntity == null)
                    return RequestResult<CategoriaPrecoDto>.BadRequest("Categoria não localizada");

                var dto = DtoMapper.ParceCategoriaPrecoDto(categoriaPrecoEntity);

                return RequestResult<CategoriaPrecoDto>.Ok(dto);
            }
            catch (Exception ex)
            {

                return RequestResult<CategoriaPrecoDto>.BadRequest(ex.Message);
            }
        }
    }
}
