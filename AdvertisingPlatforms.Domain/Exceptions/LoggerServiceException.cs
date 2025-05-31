using AdvertisingPlatforms.Domain.Exceptions.Base;

namespace AdvertisingPlatforms.Domain.Exceptions
{
    /// <summary>
    /// Logger service Exception
    /// </summary>
    public class LoggerServiceException : BusinessException
    {
        /// <summary>
        /// Logger service exception.
        /// </summary>
        /// <param name="message">Message.</param>
        public LoggerServiceException(string message) : base(message) { }

        /// <summary>
        /// Logger service exception.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner error.</param>
        public LoggerServiceException(string message, Exception innerException) : base(message, innerException) { }
    }
}
