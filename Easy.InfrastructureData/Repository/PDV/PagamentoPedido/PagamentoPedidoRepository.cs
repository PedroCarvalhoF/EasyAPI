﻿using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.PagamentoPedido;
using Easy.Domain.Intefaces.Repository.PDV.PagamentoPedido;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Tools;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository.PDV.PagamentoPedido;

public class PagamentoPedidoRepository : BaseRepository<PagamentoPedidoEntity>, IPagamentoPedidoRepository<PagamentoPedidoEntity, FiltroBase>
{
    private DbSet<PagamentoPedidoEntity> _dbSet;
    public PagamentoPedidoRepository(MyContext context) : base(context)
    {
        _dbSet = context.Set<PagamentoPedidoEntity>();
    }

    public async Task<PagamentoPedidoEntity> GetPagamentoPedidoById(Guid id, FiltroBase filtro)
    {
        try
        {
            var query = _dbSet.AsTracking();

            query = query.FiltroCliente(filtro);

            query = query.Where(p => p.Id == id);

            var pagamentoEntity = await query.SingleOrDefaultAsync();

            return pagamentoEntity ?? new PagamentoPedidoEntity();

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }
}
