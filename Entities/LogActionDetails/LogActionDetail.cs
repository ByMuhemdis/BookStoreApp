using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entities.LogActionDetails
{
    public class LogActionDetail
    {
        public object? ModelName { get; set; }
        public object? Controller { get; set; }
        public object? Action { get; set; }
        public object? id { get; set; }
        public object? CreatAt { get; set; }

        public LogActionDetail()
        {
            CreatAt = DateTime.UtcNow;
        }

        public override string ToString()
        {
           return JsonSerializer.Serialize(this);
        }
    }
}
