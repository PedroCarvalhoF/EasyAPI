using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.FormaPagamento;
using Easy.Domain.Intefaces.Repository.PDV.FormaPagamento;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Tools;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository.PDV.FormaPagamento
{
    public class FormaPagamentoRepository<T, F> : IFormaPagamentoRepository<T, F> where T : FormaPagamentoEntity where F : FiltroBase
    {
        private readonly MyContext _context;
        private readonly DbSet<FormaPagamentoEntity> _dbSet;
        public FormaPagamentoRepository(MyContext context)
        {
            _context = context;
            _dbSet = context.Set<FormaPagamentoEntity>();
        }


        public async Task<bool> CodigoFormaPagamentoExists(int codigo, string formaPagamento, F userFiltro)
        {
            try
            {
                var resultExists = await _dbSet.AsNoTracking()
                    .FiltroCliente(userFiltro)
                    .AnyAsync(f => f.Codigo == codigo || f.DescricaFormaPagamento.ToLower() == formaPagamento.ToLower());

                return resultExists;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(Guid id, F userFiltro)
        {
            try
            {
                var formaPagamento = await SelectAsync(id, userFiltro);
                if (formaPagamento == null)
                    throw new ArgumentException("Forma de pagamento não encontrada. ");

                _context.Remove(formaPagamento);
                return true;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<FormaPagamentoEntity> InsertAsync(T item, F userFiltro)
        {
            try
            {
                var codigoDescricaoExists = await CodigoFormaPagamentoExists(item.Codigo, item.DescricaFormaPagamento, userFiltro);
                if (codigoDescricaoExists)
                    throw new ArgumentException("Código e forma de pagamento devem ser unicos");

                var result = await _context.AddAsync(item);
                return item;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<FormaPagamentoEntity> SelectAsync(Guid id, F userFiltro)
        {
            try
            {
                var formaPagamento = await _dbSet.AsNoTracking()
                    .FiltroCliente(userFiltro)
                    .SingleOrDefaultAsync(f => f.Id == id);

                return formaPagamento;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<FormaPagamentoEntity>> SelectAsync(F userFiltro)
        {
            try
            {
                var formasEntities = await _dbSet.AsNoTracking()
                    .FiltroCliente(userFiltro)
                    .OrderBy(forma => forma.DescricaFormaPagamento)
                    .ToArrayAsync();

                return formasEntities;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<FormaPagamentoEntity> UpdateAsync(T item, F userFiltro)
        {
            try
            {
                var result = await _dbSet.AsNoTracking().SingleOrDefaultAsync(p => p.Id.Equals(item.Id));
                item.DataCriacao(result.CreateAt);
                _context.Entry(result).CurrentValues.SetValues(item);
                _context.Update(item);
                return item;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
