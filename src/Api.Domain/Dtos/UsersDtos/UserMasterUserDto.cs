namespace Domain.Dtos.UsersDtos
{
    public class UserMasterUserDto
    {
        public virtual UserMasterClienteDto? UserMasterClienteIdentity { get; set; }
        public virtual UserDto? User { get; set; }
    }
}
