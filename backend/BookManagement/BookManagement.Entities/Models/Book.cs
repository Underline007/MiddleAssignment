using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagement.Entities.Models
{
    public class Book
    {
        [Key]
        public Guid BookID { get; set; }

        public Guid AuthorID { get; set; }
        public Guid PublisherID { get; set; }

        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        public int PublicationYear { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        [StringLength(255)]
        public string? Image { get; set; }

        [ForeignKey("AuthorID")]
        public virtual Author? Author { get; set; }

        [ForeignKey("PublisherID")]
        public virtual Publisher? Publisher { get; set; }

        public virtual ICollection<BookGenre>? BookGenres { get; set; }
        public virtual ICollection<OrderItem>? OrderItems { get; set; }
        public virtual Inventory? Inventory { get; set; }
    }
}
