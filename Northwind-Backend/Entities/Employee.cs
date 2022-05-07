namespace Northwind_Backend.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [MinLength(2)]
        [Required]
        [MaxLength(100)]
        public string Firstname { get; set; }
        [MinLength(2)]
        [Required]
        [MaxLength(100)]
        public string Lastname { get; set; }
        [MinLength(2)]
        [MaxLength(100)]
        public string? Title { get; set; }
        [MinLength(2)]
        [MaxLength(100)]
        public string? Country { get; set; }
        [MinLength(2)]
        [MaxLength(100)]
        public string? City { get; set; }
        public DateTime? BirthDate { get; set; }
        
        public string? ImageName { get; set; }

    }
}
