using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Pagination
{
    public class BookPaginationParameters:PaginationRequestParameters
    {

        //Filtreleme için book içersine tanımlanan proplar 
        public uint MinPrice { get; set; }
        public uint MaxPrice { get; set; }
        public bool ValidePriceRagce => MaxPrice > MinPrice;
    }
}
