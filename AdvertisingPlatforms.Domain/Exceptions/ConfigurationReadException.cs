namespace AdvertisingPlatforms.Domain.Exceptions
{
    /// <summary>
    /// Configuration read exception.
    /// </summary>
    public class ConfigurationReadException : Exception
    {
        /// <summary>
        /// Configuration read exception.
        /// </summary>
        /// <param name="message">Message.</param>
        public ConfigurationReadException(string message) : base(message) { }

        /// <summary>
        /// Configuration read exception.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner error.</param>
        public ConfigurationReadException(string message, Exception innerException) : base(message, innerException) { }
    }
}
