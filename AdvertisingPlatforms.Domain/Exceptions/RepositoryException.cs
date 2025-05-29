namespace AdvertisingPlatforms.Domain.Exceptions
{
    /// <summary>
    /// Exception when working with repository.
    /// </summary>
    public class RepositoryException : Exception
    {
        /// <summary>
        /// Exception when working with repository.
        /// </summary>
        /// <param name="message">Message.</param>
        public RepositoryException(string message) : base(message) { }

        /// <summary>
        /// Exception when working with repository.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="innerException">Inner error.</param>
        public RepositoryException(string message, Exception innerException) : base(message, innerException) { }
    }
}
