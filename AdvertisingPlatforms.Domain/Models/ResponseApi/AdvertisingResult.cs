using AdvertisingPlatforms.Domain.Models.BaseModels;

namespace AdvertisingPlatforms.Domain.Models.ResponseApi
{
    /// <summary>
    /// Collection advertising for response.
    /// </summary>
    public class AdvertisingResult: BaseResponse
    {
        /// <summary>
        /// Collection advertising platforms.
        /// </summary>
        public IReadOnlyList<Advertising> Advertisings { get; }

        /// <summary>
        /// Create new model.
        /// </summary>

        /// <param name="advertisings">Collection advertising platforms.</param>
        public AdvertisingResult(IReadOnlyList<Advertising> advertisings) : base(true)
        {
            Advertisings = advertisings;
        }
    }
}
