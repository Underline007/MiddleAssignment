using System;
using System.ComponentModel.DataAnnotations;

namespace BookManagement.Application.Dtos
{
    public class CreateEditInventoryDto
    {
        [Required]
        public Guid BookID { get; set; }

        [Required]
        public int Total { get; set; }

        [Required]
        public DateTime DateModified { get; set; }
    }
}
