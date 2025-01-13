using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOs.AuthorDtos
{
    public class AuthorDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Biography { get; set; }
        public DateTime? BirthYear { get; set; }

     

    }
}
