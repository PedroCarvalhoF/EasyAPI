using Api.Domain.Entities.CategoriaPreco;
using Domain.UserIdentity.Masters;

namespace Domain.Interfaces.Repository
{
    public interface ICategoriaPrecoRepository
    {
        Task<IEnumerable<CategoriaPrecoEntity>> GetAll(UserMasterUserDtoCreate users);
        Task<CategoriaPrecoEntity> GetIdCategoriaPreco(Guid id, UserMasterUserDtoCreate users);
    }
}
