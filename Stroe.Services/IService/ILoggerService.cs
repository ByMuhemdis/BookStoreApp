using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stroe.Services.IService
{
    public interface ILoggerService
    {
        void logInfo(string message);
        void logError(string message);
        void logWarning(string message);
        void logDebugs(string message);
    }
}
