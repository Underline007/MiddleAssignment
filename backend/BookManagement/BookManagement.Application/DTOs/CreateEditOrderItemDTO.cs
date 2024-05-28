using System;
using System.ComponentModel.DataAnnotations;

namespace BookManagement.Application.Dtos
{
    public class CreateEditOrderItemDto
    {
        [Required]
        public Guid BookID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }
    }
}
