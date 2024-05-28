using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookManagement.Application.Dtos
{
    public class CreateEditBookDto
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public Guid AuthorID { get; set; }

        [Required]
        public Guid PublisherID { get; set; }

        public int PublicationYear { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        public IFormFile? Image { get; set; }

        // List of Genre IDs to link the book to existing genres
        public List<Guid> GenreIds { get; set; } = new List<Guid>();
    }
}
