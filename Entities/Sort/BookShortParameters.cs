using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Sort
{
    public class BookShortParameters
    {
        public string? OrderBy { get; set; }
        public BookShortParameters()
        {
            OrderBy = "id";//id e göre defoult oldugunda sıralanacak
        }
    }
}
