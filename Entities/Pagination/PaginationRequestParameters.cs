using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Pagination
{
    public class PaginationRequestParameters
    {
        const int MaxPageSize = 50;

        public int PageNumber { get; set; }

        public int _pageSize;

        public int Pagesize
        {
            get { return _pageSize;; }
            set { _pageSize = value > MaxPageSize ? MaxPageSize :value; }//eger istenilen sayı 50 den buyukse sade elli dönderecegim ama kucuse istelilen sayıyı dönecegim
        }

    }
}
