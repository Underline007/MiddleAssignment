using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Application.DTOs
{
    public class CreateEditPublisherDTO
    {
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        public List<Guid> BookIds { get; set; } = new List<Guid>();

    }
}
