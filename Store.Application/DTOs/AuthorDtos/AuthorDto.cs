using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOs.AuthorDtos
{
    public class AuthorDto
    {
        [Required(ErrorMessage = "blank Cannot be passed")]//bunlar dogrulama demektir
        [MinLength(2)]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "blank Cannot be passed")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "blank Cannot be passed")]
        public string? Biography { get; set; }
        public DateTime? BirthYear { get; set; }



    }
}
