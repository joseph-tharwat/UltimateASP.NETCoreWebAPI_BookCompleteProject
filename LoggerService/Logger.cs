
using NLog;

using Contracts.Logger;
namespace LoggerService
{
    public class MyLogger:ILoggerService
    {
        private ILogger logger = LogManager.GetCurrentClassLogger();
        public void LogInfo(string message)
        {
            logger.Info(message);
        }

        public void LogDebuge(string message)
        {
            logger.Debug(message); 
        }
    }
}
