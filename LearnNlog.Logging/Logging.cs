using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnNlog.Logging
{
    public static class WriteLog
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static void Trace(string message, string application, string logger)
        {
            var logInfo = LoggingFactory.Create(application, LogLevel.Trace, message, logger);
            _logger.Log(logInfo);
        }

        public static void Debug(string message, string application, string logger)
        {
            var logInfo = LoggingFactory.Create(application, LogLevel.Debug, message, logger);
            _logger.Log(logInfo);
        }

        public static void Info(string message, string application, string logger)
        {
            var logInfo = LoggingFactory.Create(application, LogLevel.Info, message, logger);
            _logger.Log(logInfo);
        }

        public static void Warn(string message, string application, string logger)
        {
            var logInfo = LoggingFactory.Create(application, LogLevel.Warn, message, logger);
            _logger.Log(logInfo);
        }

        public static void Error(string message, string application, string logger, Exception e)
        {
            var logInfo = LoggingFactory.Create(application, LogLevel.Error, message, logger, e);
            _logger.Log(logInfo);
        }

        public static void Fatal(string message, string application, string logger, Exception e)
        {
            var logInfo = LoggingFactory.Create(application, LogLevel.Fatal, message, logger, e);
            _logger.Log(logInfo);
        }
    }
}
