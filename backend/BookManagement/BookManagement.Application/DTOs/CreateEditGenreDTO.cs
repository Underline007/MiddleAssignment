using System;
using System.ComponentModel.DataAnnotations;

namespace BookManagement.Application.Dtos
{
    public class CreateEditGenreDto
    {
        [Required]
        [StringLength(50)]
        public string GenreName { get; set; } = string.Empty;
    }
}
