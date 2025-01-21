using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Sort
{
    public static class OrderQueryBuilder
    {
        public static string CreateOrderBy<T>(string orderByQueryString)
        {
            var OrderPrams = orderByQueryString.Trim().Split(',');//gelen degerin boşluklarını al ve virgule  göre böl  

            var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);//nesne üzerinden propery (örn suan skill de çalıştıgımıza göre skill içindeki id,title gibi bilgileri almak )
            var OrderQueryBuilder = new StringBuilder();

            foreach (var param in OrderPrams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(' ')[0];

                var objectPropery = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectPropery is null)
                    continue;

                var direction = param.EndsWith(" desc") ? "descending" : "ascending";

                OrderQueryBuilder.Append($"{objectPropery.Name.ToString()} {direction},");


            }

            var orderQuery = OrderQueryBuilder.ToString().TrimEnd(',', ' ');
            return orderQuery;
        }
    }
}
