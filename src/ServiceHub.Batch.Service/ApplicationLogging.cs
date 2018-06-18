using Microsoft.Extensions.Logging;

namespace ServiceHub.Batch.Service
{
    public static class ApplicationLogging
    {
        private static ILoggerFactory _Factory = null;
        private static string categoryName;

        public static void ConfigureLogger(string _categoryName)
        {
            categoryName = _categoryName;
        }

        public static ILoggerFactory LoggerFactory
        {
            get
            {
                if (_Factory == null)
                {
                    _Factory = new LoggerFactory();
                }
                return _Factory;
            }
            set { _Factory = value; }
        }
        public static ILogger CreateLogger() => LoggerFactory.CreateLogger(categoryName);
    }
}
