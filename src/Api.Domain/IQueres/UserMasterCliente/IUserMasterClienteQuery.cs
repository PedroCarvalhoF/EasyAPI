using Domain.UserIdentity.Masters;

namespace Domain.IQueres.UserMasterCliente
{
    public interface IUserMasterClienteQuery<T>
    {
        IQueryable<UserMasterClienteEntity> FullInclude(IQueryable<UserMasterClienteEntity> query);
        IQueryable<UserMasterClienteEntity> WhereByClienteMaster(IQueryable<UserMasterClienteEntity> query, Guid idClienteMaster);
    }
}
