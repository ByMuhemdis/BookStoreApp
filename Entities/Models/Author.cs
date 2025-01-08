using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Author :BaseEntity // Yazar
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Biography { get; set; }
        public DateTime? BirthYear { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
