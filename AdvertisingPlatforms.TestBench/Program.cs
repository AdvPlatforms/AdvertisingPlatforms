using BenchmarkDotNet.Running;

namespace AdvertisingPlatforms.TestBench
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<FileParserTest>();
        }
    }
}
