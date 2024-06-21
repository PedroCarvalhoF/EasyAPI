using Easy.Domain.Intefaces.Repository.UserMasterUser;
using Easy.Services.DTOs;
using MediatR;

namespace Easy.Services.CQRS.UserMasterUser.Queries;

public class UserMasterUserGetAllAsync : IRequest<RequestResult>
{
    public class UserMasteruserGetAllHandler : IRequestHandler<UserMasterUserGetAllAsync, RequestResult>
    {
        private readonly IUserMasterUserDapperRepository _repository;

        public UserMasteruserGetAllHandler(IUserMasterUserDapperRepository repository)
        {
            _repository = repository;
        }

        public async Task<RequestResult> Handle(UserMasterUserGetAllAsync request, CancellationToken cancellationToken)
        {
            try
            {
                var entities = await _repository.GetUsersMastersClientesAsync();
                return new RequestResult().Ok(entities);
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}
