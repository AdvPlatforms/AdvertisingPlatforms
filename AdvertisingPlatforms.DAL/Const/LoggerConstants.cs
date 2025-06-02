namespace AdvertisingPlatforms.DAL.Const
{
    /// <summary>
    /// Messages for information.
    /// </summary>
    public static class LoggerConstants
    {
        public static string FilePath => "logs/log-.log";
        public static string OutputTemplate => "{Timestamp:HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}";
    }
}
