namespace Easy.Services.DTOs.UserClaims
{
    public class DtoUserClaims
    {
        public string UserMasterId { get; private set; }
        public string UserId { get; private set; }
        public string UserName { get; private set; }

        public DtoUserClaims(string userMasterId, string userId, string userName)
        {
            UserMasterId = userMasterId;
            UserId = userId;
            UserName = userName;
        }
    }
}