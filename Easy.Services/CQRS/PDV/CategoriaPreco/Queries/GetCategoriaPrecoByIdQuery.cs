using AutoMapper;
using Easy.Domain.Entities;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.CategoriaPreco;
using MediatR;

namespace Easy.Services.CQRS.PDV.CategoriaPreco.Queries;

public class GetCategoriaPrecoByIdQuery : BaseCommands<CategoriaPrecoDto>
{
    public Guid Id { get; set; }
    public class GetCategoriaPrecoByIdQueryHandler(IUnitOfWork _repository, IMapper _mapper) : IRequestHandler<GetCategoriaPrecoByIdQuery, RequestResult<CategoriaPrecoDto>>
    {
        public async Task<RequestResult<CategoriaPrecoDto>> Handle(GetCategoriaPrecoByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var categoriaPrecoEntity = await _repository.CategoriaPrecoRepository.SelectAsync(request.Id, request.GetFiltro());

                var dto = _mapper.Map<CategoriaPrecoDto>(categoriaPrecoEntity);

                return RequestResult<CategoriaPrecoDto>.Ok(dto);
            }
            catch (Exception ex)
            {

                return RequestResult<CategoriaPrecoDto>.BadRequest(ex.Message);
            }
        }
    }
}
