using AdvertisingPlatforms.Domain.Models;

namespace AdvertisingPlatforms.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface for logger service.
    /// </summary>
    public interface ILoggerService
    {
        /// <summary>
        /// Log on start method.
        /// </summary>
        /// <param name="objectName">Class name.</param>
        /// <param name="methodName">Method name</param>
        /// <returns>Id method in logger service.</returns>
        public int LogStart(string objectName, string methodName);

        /// <summary>
        /// Log on end method.
        /// </summary>
        /// <param name="methodId">Id method in logger service.</param>
        public void LogEnd(int methodId);

        /// <summary>
        /// Log for error.
        /// </summary>
        /// <param name="exceptionInfo">Information for exception.</param>
        public void LogError(ExceptionInfo exceptionInfo);

        /// <summary>
        /// Log for information.
        /// </summary>
        /// <param name="infoMessage">Information message.</param>
        /// <param name="objectName">Class name.</param>
        /// <param name="methodName">Method name</param>
        public void LogInfo(string infoMessage,string objectName, string methodName);

        /// <summary>
        /// Log for information.
        /// </summary>
        /// <param name="infoMessage">Information message.</param>
        /// <param name="methodId">Id method in logger service.</param>
        public void LogInfo(string infoMessage, int methodId);
    }
}
