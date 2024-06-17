using Application.UseCases.Commands;
using Domain.Dtos;
using Domain.UserIdentity.Masters;

namespace Application.UseCases.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        Task<RequestResult> Handler(T command, UserMasterUserDtoCreate users);
    }
}
