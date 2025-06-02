using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Models;
using AdvertisingPlatforms.Domain.Models.ResponseApi;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingPlatforms.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class LocationsController : Controller
    {
        private readonly ILocationService _locationService;
        private readonly ILoggerService _loggerService;

        public LocationsController(ILocationService locationService, ILoggerService loggerService)
        {
            _locationService = locationService;
            _loggerService = loggerService;
        }

        /// <summary>
        /// Get location by id.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Location.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType<LocationResult>(StatusCodes.Status200OK)]
        public IActionResult Get(int id)
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(Get));
            var result = _locationService.GetById(id);

            var okResult = new LocationResult([result!]);

            _loggerService.LogEnd(logId);
            return Ok(okResult);
        }

        /// <summary>
        /// Get all locations.
        /// </summary>
        /// <returns>Collection locations.</returns>
        [HttpGet]
        [ProducesResponseType<LocationResult>(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(GetAll));

            var result = _locationService.GetAll();

            var okResult = new LocationResult(result?.ToList()!);

            _loggerService.LogEnd(logId);
            return Ok(okResult);
        }

        /// <summary>
        /// Add location.
        /// </summary>
        /// <param name="location">Location.</param>
        [HttpPost]
        public IActionResult Add(Location location)
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(Add));
            _locationService.Add(location);

            _loggerService.LogEnd(logId);
            return Ok();
        }

        /// <summary>
        /// Delete location by id.
        /// </summary>
        /// <param name="id">Id.</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(Delete));
            _locationService.Delete(id);

            _loggerService.LogEnd(logId);
            return Ok();
        }

        /// <summary>
        /// Update location.
        /// </summary>
        /// <param name="location">Location.</param>
        [HttpPatch]
        public IActionResult Update(Location location)
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(Update));
            _locationService.Update(location);

            _loggerService.LogEnd(logId);
            return Ok();
        }
    }
}
