using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagement.Entities.Models
{
    public class OrderItem
    {
        public Guid OrderID { get; set; }
        public Guid BookID { get; set; }
        public int Quantity { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        [ForeignKey("OrderID")]
        public virtual Order? Order { get; set; }

        [ForeignKey("BookID")]
        public virtual Book? Book { get; set; }
    }
}
