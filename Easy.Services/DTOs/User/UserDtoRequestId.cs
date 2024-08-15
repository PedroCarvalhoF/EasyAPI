using System.ComponentModel.DataAnnotations;

namespace Easy.Services.DTOs.User
{
    public class UserDtoRequestId
    {
        [Required]
        public Guid IdUser { get; private set; }

        public UserDtoRequestId(Guid idUser)
        {
            IdUser = idUser;
        }
    }
}
