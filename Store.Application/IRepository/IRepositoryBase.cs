using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.IRepository
{
    public interface IRepositoryBase<T> where T : class
    {
        DbSet<T> Table { get; }
    }
}
