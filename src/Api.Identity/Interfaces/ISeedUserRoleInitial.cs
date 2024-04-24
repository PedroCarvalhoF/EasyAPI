namespace Api.Identity.Interfaces
{
    public interface ISeedUserRoleInitial
    {
        Task SeedRolesAsync();
        Task SeedUsersAsync();
    }
}
