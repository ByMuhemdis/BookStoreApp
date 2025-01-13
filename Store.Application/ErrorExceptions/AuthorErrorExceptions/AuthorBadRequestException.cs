using Store.Application.ErrorExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Store.Application.AuthorErrorExceptions
{
    public class AuthorBadRequestException : BadRequestException
    {
        public AuthorBadRequestException(string? message) : base(message)
        {
        }
    }
}
