
namespace Northwind_Backend.Entities
{
    [Table("Category")]
    public class Category 
    {
        public int Id { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [MinLength(2)]
        [MaxLength(100)]
        [Required]
        public string Description { get; set; }
        public string? ImageName { get; set; }
    }
}
