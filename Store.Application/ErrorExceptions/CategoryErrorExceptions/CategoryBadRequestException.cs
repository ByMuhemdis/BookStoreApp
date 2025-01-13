using Store.Application.ErrorExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.CategoryErrorExceptions
{
    public class CategoryBadRequestException : BadRequestException
    {
        public CategoryBadRequestException(string? message) : base(message)
        {
        }
    }
}
