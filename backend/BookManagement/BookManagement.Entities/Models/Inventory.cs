using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagement.Entities.Models
{
    public class Inventory
    {
        [Key]
        public Guid BookID { get; set; }

        public int Total { get; set; }

        public DateTime DateModified { get; set; }

        [ForeignKey("BookID")]
        public virtual Book? Book { get; set; }
    }
}
