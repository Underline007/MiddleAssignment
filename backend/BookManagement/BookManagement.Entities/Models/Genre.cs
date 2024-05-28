using System.ComponentModel.DataAnnotations;

namespace BookManagement.Entities.Models
{
    public class Genre
    {
        [Key]
        public Guid GenreID { get; set; }

        [StringLength(50)]
        public string GenreName { get; set; } = string.Empty;

        public virtual ICollection<BookGenre>? BookGenres { get; set; }
    }
}
