using Store.Application.ErrorExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.AuthorErrorExceptions
{
    public class AuthorNotfoundException : NotFounException
    {
        public AuthorNotfoundException(int? id) : base($"No such Id :{id} value was found")
        {
        }
    }
}
