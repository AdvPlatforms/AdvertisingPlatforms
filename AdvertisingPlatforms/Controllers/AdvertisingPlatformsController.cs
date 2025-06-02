using AdvertisingPlatforms.DAL.Const;
using AdvertisingPlatforms.Domain.Exceptions;
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
        private readonly ILoggerService _loggerService;
        private const string PrefLocationName = @"/";

        public AdvertisingPlatformsController(
            IAdvertisingPlatformService advertisingPlatformService,
            IAdvertisingService advertisingService,
            ILocationService locationService,
            ILoggerService loggerService,
            IFileReader reader)
        {
            _advertisingPlatformService = advertisingPlatformService;
            _advertisingService = advertisingService;
            _locationService = locationService;
            _loggerService = loggerService;
            _reader = reader;
        }

        /// <summary>
        /// Get advertising for location.
        /// </summary>
        /// <param name="location">Location to search for advertising platforms.</param>
        [HttpGet("{*location}")]
        [ProducesResponseType<AdvertisingPlatformsResult>(StatusCodes.Status200OK)]
        public IActionResult GetAdvertisingPlatforms(string location)
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(GetAdvertisingPlatforms));

            string locationName = PrefLocationName + location;
            var advertisingForLocation = _advertisingPlatformService.GetAdvertisingPlatformsForLocation(locationName);

            var okResult = new AdvertisingPlatformsResult(advertisingForLocation!);

            _loggerService.LogEnd(logId);
            return Ok(okResult);        
        }

        /// <summary>
        /// Replace the advertising data.
        /// </summary>
        /// <param name="file">File with new advertising data.</param>
        [HttpPost]
        [ProducesResponseType<AdvertisingPlatformsUpdateResult>(StatusCodes.Status200OK)]
        public async Task<IActionResult> ReplaceAdvertisingData(IFormFile file)
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(ReplaceAdvertisingData));

            var data = await _reader.GetDataFromFileAsync(file);

            _advertisingPlatformService.ReplaceRepository(data!.AdvertisingPlatforms);
            var countAdvertising = _advertisingService.ReplaceRepository(data.Advertising);
            var countLocations = _locationService.ReplaceRepository(data.Locations);

            var okResult = new AdvertisingPlatformsUpdateResult(countAdvertising, countLocations);

            _loggerService.LogEnd(logId);
            return Ok(okResult);
        }
    }
}
