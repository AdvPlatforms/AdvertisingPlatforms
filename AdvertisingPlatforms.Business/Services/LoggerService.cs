using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog;
using System.Reflection;
using System.Security.AccessControl;

namespace AdvertisingPlatforms.Business.Services
{
    public class LoggerService : ILoggerService
    {
        private readonly ILogger<LoggerService> _logger;
        private readonly string _requestId;
        public LoggerService(ILogger<LoggerService> logger, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _requestId = contextAccessor.HttpContext?.TraceIdentifier ?? "";
        }

        public void LogStart(string objectName, string methodName)
        {
            _logger.LogInformation("|Start|{objectName}.{methodName}(), RequestID: {_requestId}", objectName, methodName, _requestId);
        }

        public void LogEnd(string objectName, string methodName)
        {
            _logger.LogInformation("|End|{objectName}.{methodName}(), RequestID: {_requestId}", objectName, methodName, _requestId);
        }

        public void LogError(ExceptionInfo exceptionInfo)
        {
            _logger.LogError("{exceptionInfo}, RequestID: {_requestId}", exceptionInfo, _requestId);
        }

        public void LogInfo(string infoMessage, string objectName, string methodName)
        {
            _logger.LogInformation("|Info|{infoMessage}, {objectName}.{methodName}()", infoMessage,objectName, methodName);
        }
    }
}
