using AdvertisingPlatforms.Business.Services.FileHandlingServices;
using AdvertisingPlatforms.Domain.Interfaces.Services;
using BenchmarkDotNet.Attributes;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisingPlatforms.TestBench
{
    [MemoryDiagnoser]
    [RankColumn]
    public class FileParserTest
    {
        FileParser _fileParser;
        string _fileContentFullCorrectData;
        string _fileContentNotCorrectData;
        string _fileContentWithCorrectAndNoCorrectData;

        public FileParserTest()
        {
            var mockLogger = new Mock<ILoggerService>();
            mockLogger.Setup(x => x.LogStart(It.IsAny<string>(), It.IsAny<string>())).Returns(1);
            _fileParser = new(mockLogger.Object);

            _fileContentFullCorrectData = GetFileContent(@"ReaderTestFiles\data1.txt");
            _fileContentWithCorrectAndNoCorrectData = GetFileContent(@"ReaderTestFiles\data2.txt");
            _fileContentNotCorrectData = GetFileContent(@"ReaderTestFiles\data3.txt");
            
        }

        private string GetFileContent(string filePath)
        {
            using StreamReader streamReader = new(filePath);
            var fileContent = streamReader.ReadToEnd();

            return fileContent;
        }

        [Benchmark]
        public void GetParseDataFullCorrectData() 
        {
            _fileParser.GetParseData(_fileContentFullCorrectData);
        }

        [Benchmark]
        public void ContentWithCorrectAndNoCorrectData()
        {
            _fileParser.GetParseData(_fileContentWithCorrectAndNoCorrectData);
        }

        [Benchmark]
        public void GetParseDataNotCorrectData()
        {
            _fileParser.GetParseData(_fileContentNotCorrectData);
        }
    }
}
