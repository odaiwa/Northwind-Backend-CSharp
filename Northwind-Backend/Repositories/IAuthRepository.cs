namespace Northwind_Backend.Repositories
{
    public interface IAuthRepository
    {
        bool IsUsernameTakenAsync(string username);
        Task<bool> RegisterUserAsync(User user);
        Task<User> LoginAsync(Credentials creds);

    }
}
