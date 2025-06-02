namespace AdvertisingPlatforms.Domain.Exceptions.Base
{
    /// <summary>
    /// Custom error for this application.
    /// </summary>
    public abstract class BusinessException : Exception
    {
        /// <summary>
        /// Custom error for this application.
        /// </summary>
        /// <param name="message">Message.</param>
        protected BusinessException(string message) : base(message) { }

        /// <summary>
        /// Custom error for this application.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner error.</param>
        protected BusinessException(string message, Exception innerException) : base(message, innerException) { }
    }
}
