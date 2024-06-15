using Api.Domain.Dtos.CategoriaPrecoDtos;
using Domain.Dtos;
using Domain.UserIdentity.Masters;

namespace Api.Domain.Interfaces.Services.CategoriaPreco
{
    public interface ICategoriaPrecoService
    {
        Task<RequestResult> GetAll(UserMasterUserDtoCreate users);
        Task<RequestResult> GetIdCategoriaPreco(Guid id, UserMasterUserDtoCreate users);
        Task<RequestResult> Create(CategoriaPrecoDtoCreate create, UserMasterUserDtoCreate users);
        Task<RequestResult> Update(CategoriaPrecoDtoUpdate update, UserMasterUserDtoCreate users);      
    }
}