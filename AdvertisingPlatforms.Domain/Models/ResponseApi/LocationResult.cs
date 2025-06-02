using AdvertisingPlatforms.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisingPlatforms.Domain.Models.ResponseApi
{
    /// <summary>
    /// Collection locations for response.
    /// </summary>
    public class LocationResult : BaseResponse
    {
        /// <summary>
        /// Collection locations platforms.
        /// </summary>
        public IReadOnlyList<Location> Locations { get; }

        /// <summary>
        /// Create new model.
        /// </summary>

        /// <param name="locations">Collection locations platforms.</param>
        public LocationResult(IReadOnlyList<Location> locations) : base(true)
        {
            Locations = locations;
        }
    }
}
