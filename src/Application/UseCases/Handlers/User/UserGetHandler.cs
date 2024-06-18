using Application.DTOs.User;
using Application.Results;
using AutoMapper;
using Domain.Entities.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Handlers.User
{
    public class UserGetHandler : IUserGet
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IMapper _mapper;
        public UserGetHandler(UserManager<UserEntity> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<RequestResult> GetAllAsync()
        {
            try
            {
                var users = await _userManager.Users.ToArrayAsync();

                return new RequestResult().Ok(_mapper.Map<ICollection<UserView>>(users));
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }

        public async Task<RequestResult> GetUserByEmailAsync(string email)
        {
            try
            {
                var users = await _userManager.FindByEmailAsync(email);

                return new RequestResult().Ok(users);
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }

        public async Task<RequestResult> GetUserByIdAsync(Guid id)
        {
            try
            {
                var users = await _userManager.FindByIdAsync(id.ToString());

                return new RequestResult().Ok(users);
            }
            catch (Exception ex)
            {

                return new RequestResult().BadRequest(ex.Message);
            }
        }
    }
}
