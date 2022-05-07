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
            var user = await _dataContext.Users.Where(user => user.Username == creds.Username && user.Password == creds.Password).SingleOrDefaultAsync();
            if (user != null)
                return user;
            return null;
        }

        public async Task<bool> RegisterUserAsync(User user)
        {
            _dataContext.Users.Add(user);
            if (await _dataContext.SaveChangesAsync() > 0)
                return true;
            return false;
        }

    }
}
