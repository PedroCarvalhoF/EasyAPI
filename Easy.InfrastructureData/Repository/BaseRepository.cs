﻿using Easy.Domain.Entities;
using Easy.Domain.Intefaces.Repository;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Tools;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository
{
    public class BaseRepository<T, F> : IBaseRepository<T, F> where T : BaseEntity where F : FiltroBase
    {
        protected readonly MyContext _context;
        private readonly DbSet<T> _dataset;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public async Task<T> InsertAsync(T item)
        {
            try
            {
                await _dataset.AddAsync(item);
                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<T> Update(T item)
        {
            try
            {
                // Tenta encontrar a entidade existente pelo Id
                var getItem = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

                // Verifica se a entidade foi encontrada
                if (getItem != null)
                {
                    // Atualiza os valores da entidade rastreada com os valores da entidade passada
                    _context.Entry(getItem).CurrentValues.SetValues(item);

                    // Marca a entidade como modificada
                    _context.Entry(getItem).State = EntityState.Modified;

                    // Não use _context.Update(item) para evitar o erro de múltiplas instâncias
                }
                else
                {
                    throw new Exception("Entidade não encontrada para o Id informado.");
                }

                return item;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<T> SelectAsync(Guid id, FiltroBase filtro, bool includeAll = true)
        {
            try
            {
                IQueryable<T> query = _dataset.AsNoTracking();

                if (includeAll)
                {
                    query = query.IncludeAll();
                }

                query = query.FiltroCliente(filtro);

                var result = await query.SingleOrDefaultAsync(t => t.Id == id);
                return result ?? Activator.CreateInstance<T>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<T>> SelectAsync(FiltroBase filtro, bool includeAll = true)
        {
            try
            {
                IQueryable<T> query = _dataset.AsNoTracking();

                if (includeAll)
                {
                    query = query.IncludeAll();
                }

                query = query.FiltroCliente(filtro);

                var result = await query.ToArrayAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
