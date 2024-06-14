namespace Domain.Dtos.UsersDtos
{
    public class UserMasterClienteDto
    {
        public virtual UserDto? UserMaster { get; set; }
        public virtual ICollection<UserMasterUserDto>? UsersMasterUsers { get; set; }
    }
}
