using AdvertisingPlatforms.Domain.Exceptions.Base;
using System.Reflection;
using System.Resources;

namespace AdvertisingPlatforms.DAL.Resources
{
    /// <summary>
    /// Class for message localization.
    /// </summary>
    public static class RuLocalization
    {
        private static readonly ResourceManager ResourceManager;

        static RuLocalization()
        {
            ResourceManager = new ResourceManager("AdvertisingPlatforms.DAL.Resources.RuMessages", Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Get localized message.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <returns>Localized message or string empty for fail.</returns>
        public static string GetLocalizedMessage(BusinessException exception)
        {
            return ResourceManager.GetString(exception.Message) ?? string.Empty;
        }
    }
}
