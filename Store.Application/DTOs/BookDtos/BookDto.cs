using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.DTOs.BookDtos
{
    public class BookDto
    {
        public string? Title { get; set; }
        public int? Price { get; set; }
        public int? Stock { get; set; }
        public string? Description { get; set; }
        public DateTime? PublishhedDate { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
