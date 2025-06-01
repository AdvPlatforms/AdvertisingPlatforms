using AdvertisingPlatforms.DAL.Const;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using AdvertisingPlatforms.Domain.Interfaces.Services.FileHandling;
using AdvertisingPlatforms.Domain.Models;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace AdvertisingPlatforms.Business.Services.FileHandlingServices
{
    /// <summary>
    /// Parser for file.
    /// </summary>
    public class FileParser : IFileParser
    {
        private readonly ILoggerService _loggerService;
        private readonly Regex _regex;

        public FileParser(ILoggerService loggerService)
        {
            _loggerService = loggerService;
            _regex = new(FileConstants.RowPattern);
        }

        /// <summary>
        /// Parsing data from file.
        /// </summary>
        /// <param name="fileContent">Content from file.</param>
        /// <returns>Data.</returns>
        public AdvertisingInformation GetParseData(string fileContent)
        {
            var logId = _loggerService.LogStart(this.GetType().Name, nameof(GetParseData));

            var sortFileContent = GetSortFileContent(fileContent).ToDictionary();
            //5.9kb
            var advertisingPlatforms = GetAdvertising(sortFileContent);
            //6.05kb
            var locations = sortFileContent
                .Select((x, Index) => new Location(Index + 1) { Name = x.Key });
            //6.23kb
            var advertisingInLocations =
                GetAdvertisingInLocations(sortFileContent, advertisingPlatforms, locations);
            //25.64kb
            var result = new AdvertisingInformation(
                advertisingInLocations.ToList(),
                advertisingPlatforms.ToList(),
                locations.ToList());

            //For benchmark
            //GC.Collect();


            _loggerService.LogEnd(logId);
            return result;
        }

        private IEnumerable<AdvertisingPlatform> GetAdvertisingInLocations(
              IEnumerable<KeyValuePair<string,
              IEnumerable<string>>> sortFileContent, 
              IEnumerable<Advertising> advertisingPlatforms, IEnumerable<Location> locations)
        {
            return sortFileContent
                .Select((x, Index) => new AdvertisingPlatform(
                    Index + 1,
                    locations.First(y=>y.Name == x.Key).Id,
                    advertisingPlatforms
                        .Join(x.Value, a => a.Name , d=>d , (a, d) => a.Id )
                        //.ToList()
                ));
        }

        private IEnumerable<KeyValuePair<string, IEnumerable<string>>> GetSortFileContent(string fileContent)
        {
            var advertisingLocationsPair = GetAdvertisingLocationsPair(fileContent);

            var dataWithDirectAdvertising = GetDataWithDirectAdvertising(advertisingLocationsPair);

            var sortFileContent = GetDataWithAdditionalAdvertising(dataWithDirectAdvertising);

            return sortFileContent;
        }

        private IEnumerable<KeyValuePair<string, IEnumerable<string>>> GetDataWithDirectAdvertising(IEnumerable<string[]> advertisingLocationsPair)
        {
            return advertisingLocationsPair
                .SelectMany(x =>
                    AddDirectAdvertising(x[0].Trim(), x[1].Split(FileConstants.EntitiesSplitter))
                );
        }

        private IEnumerable<KeyValuePair<string, IEnumerable<string>>> AddDirectAdvertising(string advertisingPlatformName, IEnumerable<string> locationNames)
        {
            //return locationNames
            //    .Select(x => new KeyValuePair<string,IEnumerable<string>>(x, [advertisingPlatformName]));

            foreach (var item in locationNames)
            {
                yield return new KeyValuePair<string, IEnumerable<string>>(item, [advertisingPlatformName]);
            }
        }

        private IEnumerable<KeyValuePair<string, IEnumerable<string>>> GetDataWithAdditionalAdvertising(IEnumerable<KeyValuePair<string, IEnumerable<string>>> sortFileContent)
        {
            return sortFileContent
                .Select(x => new KeyValuePair<string, IEnumerable<string>>(x.Key, GetAllAdvertisingForLocation(x.Key, sortFileContent)));
        }

        private IEnumerable<string> GetAllAdvertisingForLocation(string locationName, IEnumerable<KeyValuePair<string, IEnumerable<string>>> sortFileContent)
        {
            return sortFileContent
                .Where(x => locationName.Contains(x.Key))
                .Select(x => x.Value.First())
                .Distinct();
        }

        private IEnumerable<Advertising> GetAdvertising(IEnumerable<KeyValuePair<string, IEnumerable<string>>> sortFileContent)
        {
            var advertisingNames = sortFileContent
                .SelectMany(x => x.Value)
                .Distinct();

            var AdvertisingCollection = CreateAdvertising(advertisingNames);

            return AdvertisingCollection; 
        }

        private IEnumerable<Advertising> CreateAdvertising(IEnumerable<string> advertisingNames)
        {
            return advertisingNames.Select((x, Index) => new Advertising(Index + 1) { Name = x });
        }

        private IEnumerable<string[]> GetAdvertisingLocationsPair(string fileContent)
        {
            return fileContent
                .Split(FileConstants.RowsSplitter)
                .Where(x => _regex.IsMatch(x))
                .Select(x => x.Split(FileConstants.Splitter))
                .Where(x => x.Length == 2);
        }
    }
}
