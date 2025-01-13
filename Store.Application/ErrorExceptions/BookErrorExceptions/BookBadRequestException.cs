using Store.Application.ErrorExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.BookErrorExceptions
{
    public class BookBadRequestException : BadRequestException
    {
        public BookBadRequestException(string? message) : base(message)
        {
        }
    }
}
