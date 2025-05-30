using AdvertisingPlatforms.DAL.Const;
using AdvertisingPlatforms.Domain.Exceptions;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Interfaces.Services.FileHandling;
using AdvertisingPlatforms.Domain.Models;


namespace AdvertisingPlatforms.Business.Services.FileHandlingServices
{
    /// <summary>
    /// Reader for files containing information about advertising platforms.
    /// </summary>
    public class FileReader: IFileReader
    {
        private readonly IFileValidator _validator;
        private readonly IFileParser _parser;
        private readonly ILoggerService _loggerService;

        public FileReader(IFileValidator validator, IFileParser parser, ILoggerService loggerService)
        {
            _validator = validator;
            _parser = parser;
            _loggerService = loggerService;
        }

        /// <summary>
        /// Get data from file.
        /// </summary>
        /// <param name="file">File with data.</param>
        /// <returns>Data or null.</returns>
        /// <exception cref="ValidFileContentException"></exception>
        public async Task<AdvertisingInformation?> GetDataFromFileAsync(Microsoft.AspNetCore.Http.IFormFile file)
        {
            _loggerService.LogStart(this.GetType().Name, nameof(GetDataFromFileAsync));

            using StreamReader streamReader = new(file.OpenReadStream());

            var fileContent = await streamReader.ReadToEndAsync();

            var isValid = _validator.IsValidAdvertisingData(fileContent);

            if (!isValid.result)
            {
                throw new ValidFileContentException(isValid.error!);                
            }

            AdvertisingInformation result = _parser.GetParseData(fileContent);

            if (result.Advertising.Count == 0 ||
                result.Locations.Count == 0) 
            {
                throw new ValidFileContentException(ErrorConstants.NoCorrectFileData);
            }

            _loggerService.LogEnd(this.GetType().Name, nameof(GetDataFromFileAsync));
            return result;
        }
    }
}
