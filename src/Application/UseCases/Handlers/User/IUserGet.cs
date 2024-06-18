using Application.Results;

namespace Application.UseCases.Handlers.User
{
    public interface IUserGet
    {
        Task<RequestResult> GetAllAsync();
        Task<RequestResult> GetUserByIdAsync(Guid id);
        Task<RequestResult> GetUserByEmailAsync(string email);


    }
}
