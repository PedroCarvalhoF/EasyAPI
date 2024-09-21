using Easy.Domain.Entities.PDV.ItensPedido;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs;
using Easy.Services.DTOs.ItemPedido;
using Easy.Services.Tools.UseCase.Dto;
using MediatR;

namespace Easy.Services.CQRS.PDV.ItemPedido.Queries;

public class GetItensPedidoQuery : BaseCommands<IEnumerable<ItemPedidoDto>>
{
    public required ItemPedidoEntityFilter FilteItem { get; set; }

    public class GetItensPedidoQueryHandler(IUnitOfWork _repository) : IRequestHandler<GetItensPedidoQuery, RequestResult<IEnumerable<ItemPedidoDto>>>
    {
        public async Task<RequestResult<IEnumerable<ItemPedidoDto>>> Handle(GetItensPedidoQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var itensPedido = await _repository.ItemPedidoRepository.SelectAsync(request.FilteItem, request.GetFiltro(),true);

                var dto = DtoMapper.ParceItemPedidoDto(itensPedido);

                return RequestResult<IEnumerable<ItemPedidoDto>>.Ok(dto);
            }
            catch (Exception ex)
            {

                return RequestResult<IEnumerable<ItemPedidoDto>>.BadRequest(ex.Message);
            }
        }
    }
}
