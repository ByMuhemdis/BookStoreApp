using NLog;
using Stroe.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stroe.Services.ServicesManager
{
    public class LoggerManager : ILoggerService
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        public void logDebugs(string message)
        {
            _logger.Debug(message);
        }

        public void logError(string message)
        {
           _logger?.Error(message);
        }

        public void logInfo(string message)
        {
           _logger.Info(message);
        }

        public void logWarning(string message)
        {
            _logger.Warn(message);
        }
    }
}
