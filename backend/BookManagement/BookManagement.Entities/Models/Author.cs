using System.ComponentModel.DataAnnotations;

namespace BookManagement.Entities.Models
{
    public class Author
    {
        [Key]
        public Guid AuthorID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        [StringLength(50)]
        public string Country { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Image { get; set; }

        public virtual ICollection<Book>? Books { get; set; }
    }
}
