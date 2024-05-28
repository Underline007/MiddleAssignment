using System;
using System.Collections.Generic;

namespace BookManagement.Application.Dtos
{
    public class AuthorDto
    {
        public Guid AuthorID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Country { get; set; } = string.Empty;
        public string? Image { get; set; }
    }
}
