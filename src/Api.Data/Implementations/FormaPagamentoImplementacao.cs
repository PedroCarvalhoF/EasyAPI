using Api.Data.Context;
using Api.Data.Repository;
using Domain.Entities.FormaPagamento;
using Domain.Interfaces.Repository.PedidoFormaPagamento;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Implementations
{
    public class FormaPagamentoImplementacao : BaseRepository<FormaPagamentoEntity>, IFormaPagamentoRepository
    {
        private readonly DbSet<FormaPagamentoEntity> _dataset;
        public FormaPagamentoImplementacao(MyContext context) : base(context)
        {
            _dataset = context.Set<FormaPagamentoEntity>();
            _dataset.AsNoTracking();
        }

     
    }
}
