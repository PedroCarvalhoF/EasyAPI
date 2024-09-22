using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.Pedido;
using Easy.Domain.Intefaces;
using Easy.Services.DTOs.Pedido;
using Easy.Services.Tools.UseCase.Dto;

namespace Easy.Services.Service.Pedido;

public class PedidoServices(IUnitOfWork _repository) : IPedidoServices
{
    public async Task<bool> AtualizarPedido(Guid idPedido, FiltroBase filtro)
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

            var pedido_manipular = pedidoSelecionado.Manipular;

            pedidoSelecionado.CalcularTotalPedido();

            await _repository.PedidoBaseRepository.Update(pedidoSelecionado);
            if (!await _repository.CommitAsync())
                throw new ArgumentException("Não foi possível atualizar Pedido.");

            return true;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<PedidoDto> GetPedidoById(Guid idPedido, FiltroBase filtro)
    {
        try
        {
            var pedidoFiltro = new PedidoEntityFilter
            {
                IdPedido = idPedido,
            };

            var pedidos = await _repository.PedidoRepository.SelectAsync(pedidoFiltro, filtro);
            var pedidoSelecionado = pedidos.Single();
            return DtoMapper.ParcePedidoDto(pedidoSelecionado);
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
