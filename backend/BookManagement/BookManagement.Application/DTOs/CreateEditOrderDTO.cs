using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookManagement.Application.Dtos
{
    public class CreateEditOrderDto
    {
        [Required]
        public Guid CustomerID { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderStatus { get; set; } = string.Empty;

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Total { get; set; }

        // List of OrderItem DTOs to link items to the order
        public List<CreateEditOrderItemDto> OrderItems { get; set; } = new List<CreateEditOrderItemDto>();
    }
}
