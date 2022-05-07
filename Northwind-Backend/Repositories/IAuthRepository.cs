using Northwind_Backend.Helpers;

namespace Northwind_Backend.Repositories
{
    public interface IAuthRepository
    {
        bool IsUsernameTakenAsync(string username);
        Task<bool> RegisterUserAsync(UserDto user);
        Task<User> LoginAsync(Credentials creds);
    }
}
