using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Models;
using AdvertisingPlatforms.Domain.Models.ResponseApi;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingPlatforms.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class AdvertisingController : Controller
    {
        private readonly IAdvertisingService _advertisingService;
        private readonly ILoggerService _loggerService;
        public AdvertisingController(IAdvertisingService advertisingService, ILoggerService loggerService)
        {
            _advertisingService = advertisingService;
            _loggerService = loggerService;
        }

        /// <summary>
        /// Get advertising by id.
        /// </summary>
        /// <param name="id">Id.</param>
        /// <returns>Advertising.</returns>
        [HttpGet("{id}")]
        [ProducesResponseType<AdvertisingResult>(StatusCodes.Status200OK)]
        public IActionResult Get(int id)
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(Get));
            var result = _advertisingService.GetById(id);

            var okResult = new AdvertisingResult([result!]);

            _loggerService.LogEnd(logId);
            return Ok(okResult);
        }

        /// <summary>
        /// Get all advertising.
        /// </summary>
        /// <returns>Collection advertising.</returns>
        [HttpGet]
        [ProducesResponseType<AdvertisingResult>(StatusCodes.Status200OK)]
        public IActionResult GetAll()
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(GetAll));
            var result = _advertisingService.GetAll();

            var okResult = new AdvertisingResult(result?.ToList()!);

            _loggerService.LogEnd(logId);
            return Ok(okResult);
        }

        /// <summary>
        /// Add advertising.
        /// </summary>
        /// <param name="advertising">Advertising.</param>
        [HttpPost]
        public IActionResult Add(Advertising advertising)
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(Add));
            _advertisingService.Add(advertising);

            _loggerService.LogEnd(logId);
            return Ok();
        }

        /// <summary>
        /// Delete advertising.
        /// </summary>
        /// <param name="id">Id.</param>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(Delete));
            _advertisingService.Delete(id);

            _loggerService.LogEnd(logId);
            return Ok();
        }

        /// <summary>
        /// Update advertising.
        /// </summary>
        /// <param name="advertising">Advertising.</param>
        [HttpPatch]
        public IActionResult Update(Advertising advertising)
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(Update));
            _advertisingService.Update(advertising);

            _loggerService.LogEnd(logId);
            return Ok();
        }
    }
}
