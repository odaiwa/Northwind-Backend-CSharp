using Northwind_Backend.Helpers;
using System.Security.Cryptography;
using System.Text;

namespace Northwind_Backend.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _dataContext;

        public AuthRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        public bool IsUsernameTakenAsync(string username)
        {
            var user = _dataContext.Users.Where(u => u.Username == username).Any();
            if (user)
                return false;
            return true;
        }

        public async Task<User> LoginAsync(Credentials creds)
        {
            var user = await _dataContext.Users.Where(user => user.Username == creds.Username).SingleOrDefaultAsync();
            if (user != null)
            {
                if (VerifyPasswordHash(creds.Password, user.PasswordHash, user.PasswordSalt))
                    return user;
            }
            return null;
        }

        public async Task<bool> RegisterUserAsync(UserDto user)
        {
            CreatePasswordHash(user.Password, out byte[] PasswordHash, out byte[] PasswordSalt);

            User newUser = new User()
            {
                Username = user.Username,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PasswordHash = PasswordHash,
                PasswordSalt = PasswordSalt,
                isAdmin = false
            };

            _dataContext.Users.Add(newUser);
            if (await _dataContext.SaveChangesAsync() > 0)
                return true;
            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                var compare = computedHash.SequenceEqual(passwordHash);
                return computedHash.SequenceEqual(passwordHash);
            }
        }

    }
}
