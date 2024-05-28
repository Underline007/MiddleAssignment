using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BookManagement.Application.Dtos
{
    public class CreateEditUserDto
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [StringLength(255)]
        public string Address { get; set; } = string.Empty;

        public IFormFile? Image { get; set; };

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Password { get; set; } = string.Empty;
    }
}
