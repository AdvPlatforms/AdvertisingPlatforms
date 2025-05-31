using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Domain.Interfaces.Services
{
    public interface ILoggerService
    {
        public int LogStart(string objectName, string methodName);

        public void LogEnd(int methodId);

        public void LogError(ExceptionInfo exceptionInfo);

        public void LogInfo(string infoMessage,string objectName, string methodName);

        public void LogInfo(string infoMessage, int methodId);
    }
}
