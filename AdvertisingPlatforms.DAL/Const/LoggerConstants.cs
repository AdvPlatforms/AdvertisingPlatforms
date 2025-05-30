namespace AdvertisingPlatforms.DAL.Const
{
    /// <summary>
    /// Messages for information.
    /// </summary>
    public static class LoggerConstants
    {
        public static string FilePath => "logs/log-.txt";
        public static string OutputTemplate => "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] {Message}{NewLine}{Exception}";
    }
}
