using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Domain.Interfaces.Services
{
    public interface ILoggerService
    {
        public void LogStart(string objectName, string methodName);

        public void LogEnd(string objectName, string methodName);

        public void LogError(ExceptionInfo exceptionInfo);

        public void LogInfo(string infoMessage,string objectName, string methodName);
    }
}
