using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Models;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Reflection;
using System.Security.AccessControl;

namespace AdvertisingPlatforms.Business.Services
{
    public class LoggerService : ILoggerService
    {
        private ILogger<LoggerService> _logger;
        public LoggerService(ILogger<LoggerService> logger)
        {
            _logger = logger;
        }

        public void LogStart(string objectName, string methodName)
        {
            _logger.LogInformation("Start: {objectName}, {methodName}", objectName, methodName);
            //Console.WriteLine($"{objectName}, {methodName}");
        }

        public void LogEnd(string objectName, string methodName)
        {
            _logger.LogInformation("End: {objectName}, {methodName}", objectName, methodName);
           // Console.WriteLine($"{objectName}, {methodName}");
        }

        public void LogError(ExceptionInfo exceptionInfo)
        {
            _logger.LogError("Error: {exceptionInfo}", exceptionInfo);
            //Console.WriteLine($"{exceptionInfo}");
        }

        public void LogInfo(string infoMessage, string objectName, string methodName)
        {
            _logger.LogInformation("Info:{infoMessage}, {objectName}, {methodName}", infoMessage,objectName, methodName);
            //Console.WriteLine($"{infoMessage}, {objectName}, {methodName}");
        }
    }
}
