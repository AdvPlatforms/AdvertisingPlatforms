using AdvertisingPlatforms.DAL.Const;
using AdvertisingPlatforms.Domain.Exeptions;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Interfaces.Services.FileHandling;
using AdvertisingPlatforms.Domain.Models.ResponseApi;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingPlatforms.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class AdvertisingPlatformsController : Controller
    {
        private readonly IAdvertisingPlatformService _advertisingPlatformService;
        private readonly IAdvertisingService _advertisingService;
        private readonly ILocationService _locationService;
        private readonly IFileReader _reader;
        private const string PrefLocationName = @"/";

        public AdvertisingPlatformsController(
            IAdvertisingPlatformService advertisingPlatformService,
            IAdvertisingService advertisingService,
            ILocationService locationService,
            IFileReader reader)
        {
            _advertisingPlatformService = advertisingPlatformService;
            _advertisingService = advertisingService;
            _locationService = locationService;
            _reader = reader;
        }

        /// <summary>
        /// Get advertising for location.
        /// </summary>
        /// <param name="location">Location to search for advertising platforms.</param>
        [HttpGet("{*location}")]
        [ProducesResponseType<AdvertisingsResult>(StatusCodes.Status200OK)]
        public IActionResult GetAdvertisingPlatforms(string location)
        {
            string locationName = PrefLocationName + location;
            var advertisingForLocation = _advertisingPlatformService.GetAdvertisingPlatformsForLocation(locationName);

            if (advertisingForLocation is { Count: > 0 })
            {
                var okResult = new AdvertisingsResult(advertisingForLocation);
                return Ok(okResult);
            }
            else
            {
                throw new BusinessException(ErrorConstants.NotFound);
            }               
        }

        /// <summary>
        /// Replace the advertising data.
        /// </summary>
        /// <param name="file">File with new advertising data.</param>
        [HttpPost]
        [ProducesResponseType<AdvertisingUpdateResult>(StatusCodes.Status200OK)]
        public async Task<IActionResult> ReplaceAdvertisingData(IFormFile file)
        {
            var data = await _reader.GetDataFromFileAsync(file);

            if (data?.Advertising.Count > 0)
            {
                _advertisingPlatformService.ReplaceRepository(data.AdvertisingPlatforms);
                var countAdvertising = _advertisingService.ReplaceRepository(data.Advertising);
                var countLocations = _locationService.ReplaceRepository(data.Locations);

                var okResult = new AdvertisingUpdateResult(countAdvertising, countLocations);
                return Ok(okResult);
            }
            else
            {
                throw new BusinessException(ErrorConstants.NoCorrectFileData);
            }
        }
    }
}
