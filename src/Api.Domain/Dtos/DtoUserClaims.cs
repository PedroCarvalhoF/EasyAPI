namespace Domain.Dtos
{
    public class DtoUserClaims
    {
        public string UserMasterId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }

        public DtoUserClaims(string userMasterId, string userId, string userName)
        {
            UserMasterId = userMasterId;
            UserId = userId;
            UserName = userName;
        }
    }
}
