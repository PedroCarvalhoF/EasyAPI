using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.Pedido;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs.Pedido;
using Easy.Services.Tools.UseCase.Dto;

namespace Easy.Services.Service.Pedido;

public class PedidoServices(IUnitOfWork _repository) : IPedidoServices
{
    public async Task<PedidoDto> AtualizarPedido(Guid idPedido, FiltroBase filtro)
    {
        try
        {
            var pedidoFiltro = new PedidoEntityFilter
            {
                IdPedido = idPedido,
            };

            var pedidos = await _repository.PedidoRepository.SelectAsync(pedidoFiltro, filtro);
            if (!pedidos.Any())
                throw new ArgumentException("Pedido não localizado");
            var pedidoSelecionado = pedidos.Single();

            pedidoSelecionado.CalcularTotalPedido();

            await _repository.PedidoBaseRepository.Update(pedidoSelecionado);
            if (!await _repository.CommitAsync())
                throw new ArgumentException("Não foi possível atualizar Pedido.");

            var pedidoDto = DtoMapper.ParcePedidoDto(pedidoSelecionado);

            return pedidoDto;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
