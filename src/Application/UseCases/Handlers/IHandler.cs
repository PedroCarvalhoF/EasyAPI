using Application.Results;
using Application.UseCases.Commands;

namespace Application.UseCases.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        //Task<RequestResult> Handler(T command, UserMasterUserDtoCreate users);
    }
}
