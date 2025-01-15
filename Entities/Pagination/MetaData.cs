using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Pagination
{
    public class MetaData
    {
        public int CurretPage { get; set; } //geçerli olan sayfa 
        public int TotalPage { get; set; } //toplam sayfa
        public int PageSize { get; set; } //sayfada var olan urün sayısı
        public int TotalCount { get; set; } //toplam sayfa sayısı

        public bool HasPrevious => CurretPage > 1; //öncesinde sayfa varmı 
        public bool HasPage => CurretPage < TotalPage; //sonrasında sayfa varmı 
    }
}
