using AdvertisingPlatforms.DAL.Const;
using AdvertisingPlatforms.Domain.Exceptions;
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
        private Dictionary<int, (string, string)> _methodsInfo;
        private int _idCounter;
        public LoggerService(ILogger<LoggerService> logger, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _requestId = contextAccessor.HttpContext?.TraceIdentifier ?? "";
            _idCounter = 1;
            _methodsInfo = new();
        }

        public int LogStart(string objectName, string methodName)
        {
            _logger.LogInformation("|Start|{objectName}.{methodName}(), RequestID: {_requestId}", objectName, methodName, _requestId);

            return AddMethod(objectName, methodName);
        }

        public void LogEnd(int methodId)
        {
            var methodInfo = GetMethod(methodId);
            var objectName = methodInfo.objName;
            var methodName = methodInfo.methName;
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

        public void LogInfo(string infoMessage,int methodId)
        {
            var methodInfo = GetMethod(methodId);
            var objectName = methodInfo.objName;
            var methodName = methodInfo.methName;
            _logger.LogInformation("|Info|{infoMessage}, {objectName}.{methodName}()", infoMessage, objectName, methodName);
        }

        private int AddMethod(string objName, string methName)
        {
            int id = _idCounter++;

            _methodsInfo.Add(id, (objName, methName));

            return id;
        }

        private (string objName, string methName) GetMethod(int id)
        {
            var haveData = _methodsInfo.TryGetValue(id, out var data);

            if (haveData)
            {
                return _methodsInfo[id];
            }
            else
            {
                throw new LoggerServiceException(ErrorConstants.LoggerService);
            }
        }
    }
}
