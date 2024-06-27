using Easy.Domain.Entities;
using Easy.Domain.Entities.PDV.UserPDV;
using Easy.Domain.Enuns.Pdv.UserPDV;
using Easy.Domain.Intefaces.Repository.PDV.UserPDV;
using Easy.InfrastructureData.Context;
using Easy.InfrastructureData.Tools;
using Microsoft.EntityFrameworkCore;

namespace Easy.InfrastructureData.Repository.PDV.UsuarioPdv;

public class UsuarioPdvRepository<T, F> : IUsuarioPdvRepository<T, F> where T : UsuarioPdvEntity where F : FiltroBase
{
    protected readonly MyContext _contexto;
    private DbSet<T> _dbSet;
    public UsuarioPdvRepository(MyContext contexto)
    {
        _contexto = contexto;
        _dbSet = contexto.Set<T>();
    }

    public async Task<T> InsertAsync(T item, F filtro)
    {
        try
        {
            var userPdvExists = await SelectByIdUsuarioPdvAsync(item.UserPdvId, filtro);
            if (userPdvExists != null)
                throw new ArgumentException("Usuário já está habilitado");

            var result = await _contexto.AddAsync(item);
            return item;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<T>> SelectAsync(F filtro)
    {
        try
        {
            var result = await
                _dbSet.AsNoTracking()
                .FiltroCliente(filtro)
                .ToArrayAsync();

            return result;
        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<IEnumerable<T>> SelectAsync(UsuarioPdvFiltroEnum filtroEnum, F filtro)
    {
        try
        {
            var query = _dbSet.AsNoTracking().FiltroCliente(filtro);

            switch (filtroEnum)
            {
                case UsuarioPdvFiltroEnum.UsuariosHabilitados:

                    query = query.Where(updv => updv.Habilitado == true);

                    break;
                case UsuarioPdvFiltroEnum.UsuariosDesabilitados:

                    query = query.Where(updv => updv.Habilitado == false);
                    break;
            }

            var result = await query.ToArrayAsync();

            return result;

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<T>? SelectByIdUsuarioPdvAsync(Guid idUsuarioPdv, F filtro)
    {
        try
        {
            var result = await
                _dbSet.AsNoTracking()
                .FiltroCliente(filtro)
                .SingleOrDefaultAsync(updv => updv.UserPdvId == idUsuarioPdv);

            return result;

        }
        catch (Exception ex)
        {

            throw new Exception(ex.Message);
        }
    }

    public async Task<T> UpdateAsync(T item, F filtro)
    {
        try
        {
            var existingItem = await SelectByIdUsuarioPdvAsync(item.UserPdvId, filtro);
            if (existingItem == null)
                throw new ArgumentException("Usuário não localizado");

            item.DataCriacao(existingItem.CreateAt);
            _contexto.Entry(existingItem).CurrentValues.SetValues(item);
            _contexto.Update(item);
            return existingItem;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
