using Application.UseCases.Commands;
using Domain.Dtos;
using Domain.UserIdentity.Masters;

namespace Application.UseCases.Handlers
{
    public interface IServiceHandler<dtoCreate, dtoUpdate>
        where dtoCreate : ICommand
        where dtoUpdate : ICommand
    {
        Task<RequestResult> GetAll(UserMasterUserDtoCreate users);
        Task<RequestResult> GetById(Guid id, UserMasterUserDtoCreate users);
        Task<RequestResult> Create(dtoCreate command, UserMasterUserDtoCreate users);
        Task<RequestResult> Update(dtoUpdate command, UserMasterUserDtoCreate users);

    }
}
