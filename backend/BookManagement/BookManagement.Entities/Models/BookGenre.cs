using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagement.Entities.Models
{
    public class BookGenre
    {
        public Guid BookID { get; set; }
        public Guid GenreID { get; set; }

        [ForeignKey("BookID")]
        public virtual Book? Book { get; set; }

        [ForeignKey("GenreID")]
        public virtual Genre? Genre { get; set; }
    }
}
