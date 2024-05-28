using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagement.Entities.Models
{
    public class Order
    {
        [Key]
        public Guid OrderID { get; set; }

        public Guid CustomerID { get; set; }

        [ForeignKey("UserID")]
        public virtual User? User { get; set; }

        public DateTime OrderDate { get; set; }

        [StringLength(50)]
        public string OrderStatus { get; set; } = string.Empty;

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Total { get; set; }

        public virtual ICollection<OrderItem>? OrderItems { get; set; }
    }
}
