using AdvertisingPlatforms.Domain.Exceptions.Base;

namespace AdvertisingPlatforms.Domain.Exceptions
{
    /// <summary>
    /// Exception when trying to get a list of advertising.
    /// </summary>
    public class GetAdvertisingException : BusinessException
    {
        /// <summary>
        /// Exception when trying to get a list of advertising.
        /// </summary>
        /// <param name="message">Message.</param>
        public GetAdvertisingException(string message) : base(message) { }

        /// <summary>
        ///  Exception when trying to get a list of advertising.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner error.</param>
        public GetAdvertisingException(string message, Exception innerException) : base(message, innerException) { }
    }
}
