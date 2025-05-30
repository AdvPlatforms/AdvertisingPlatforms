using AdvertisingPlatforms.DAL.Const;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Interfaces.Services.FileHandling;
using System.Text.RegularExpressions;

namespace AdvertisingPlatforms.Business.Services.FileHandlingServices
{
    /// <summary>
    /// Validator for files.
    /// </summary>
    public class FileValidator : IFileValidator
    {
        private readonly ILoggerService _loggerService;
        public FileValidator(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        /// <summary>
        /// Validation check.
        /// </summary>
        /// <param name="data">Data for validation.</param>
        /// <returns>(True + null) or (false + error).</returns>
        public (bool result, string? error) IsValidAdvertisingData(string? data)
        {
            _loggerService.LogStart(this.GetType().Name, nameof(IsValidAdvertisingData));

            if(string.IsNullOrEmpty(data))
                return (false, ErrorConstants.NoDataFile);

            if (!data.Contains(FileConstants.Splitter))
                return (false, ErrorConstants.FileNoHaveSplitter);

            if(data.Length < 5)
                return (false, ErrorConstants.FileHaveShortData);

            if(Regex.Matches(data, FileConstants.RowsSplitter).Count == 0 &&
               !Regex.IsMatch(data, FileConstants.RowPattern))
                return (false, ErrorConstants.NoCorrectFileData);

            _loggerService.LogEnd(this.GetType().Name, nameof(IsValidAdvertisingData));
            return (true, null);
        }
    }
}
