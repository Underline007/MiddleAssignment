using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.DTOs
{
    public class CreateEditAuthorDto
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        [StringLength(50)]
        public string Country { get; set; } = string.Empty;

        public IFormFile? Image { get; set; }

        // List of Book IDs to link the author to existing books
        public List<Guid> BookIds { get; set; } = new List<Guid>();
    }
}
