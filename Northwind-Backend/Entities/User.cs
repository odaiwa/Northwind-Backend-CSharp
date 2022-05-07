namespace Northwind_Backend.Entities
{
    public class User
    {
        public User(int id, string firstName, string lastName, string username, string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Username = username;
            Password = password;
        }

        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        

    }
}
