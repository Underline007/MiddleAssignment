using System.ComponentModel.DataAnnotations;

namespace BookManagement.Entities.Models
{
    public class Publisher
    {
        [Key]
        public Guid PublisherID { get; set; }

        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Book>? Books { get; set; }
    }
}
