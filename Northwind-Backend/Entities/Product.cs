namespace Northwind_Backend.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [StringLength(100 , ErrorMessage="Name length cannot exceed 100")]
        public string Name { get; set; }

        [Range(0, 10000, ErrorMessage = "Please enter number between 0 - 10,000")]
        public float Price { get; set; }

        [Range(0, 10000, ErrorMessage = "Please enter number between 0 - 10,000")]
        public int Stock { get; set; }

        public string? ImageName { get; set; }
    }
}
