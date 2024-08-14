namespace Easy.Services.DTOs.User
{
    public class UserDtoImageResult
    {
        public UserDtoImageResult(Guid userId, string urlImage, string email)
        {
            UserId = userId;
            UrlImage = urlImage;
            Email = email;
        }

        public Guid UserId { get; private set; }
        public string Email { get;private set; }
        public string UrlImage { get; private set; }
    }
}
