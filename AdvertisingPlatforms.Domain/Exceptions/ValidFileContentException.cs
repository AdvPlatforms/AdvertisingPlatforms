using AdvertisingPlatforms.Domain.Exceptions.Base;

namespace AdvertisingPlatforms.Domain.Exceptions
{
    /// <summary>
    /// File reading exception.
    /// </summary>
    public class ValidFileContentException : BusinessException
    {
        /// <summary>
        /// File reading exception.
        /// </summary>
        /// <param name="message">Message.</param>
        public ValidFileContentException(string message) : base(message) { }

        /// <summary>
        /// File reading exception.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner error.</param>
        public ValidFileContentException(string message, Exception innerException) : base(message, innerException) { }
    }
}