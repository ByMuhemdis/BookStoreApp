using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.ErrorExceptions.BookErrorExceptions
{
    public class PriceOutofRangeBadRequestException : BadRequestException
    {
        public PriceOutofRangeBadRequestException() : base("invalid price! The price range should be between 1 and 100000.")
        {
        }
    }
}
