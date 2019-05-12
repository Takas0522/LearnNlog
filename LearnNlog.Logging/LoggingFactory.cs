using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnNlog.Logging
{
    static class LoggingFactory
    {
        public static LogEventInfo Create(string application, LogLevel logLevel, string message, string logger)
        {
            return BaseCreate(application, logLevel, message, logger);
        }

        public static LogEventInfo Create(string application, LogLevel logLevel, string message, string logger, string actionMethod)
        {
            var info = BaseCreate(application, logLevel, message, logger);
            info.Properties["ActionMethod"] = actionMethod;
            return info;
        }

        public static LogEventInfo Create(string application, LogLevel logLevel, string message, string logger, Exception e)
        {
            var info = BaseCreate(application, logLevel, message, logger);
            info.Exception = e;
            return info;
        }

        private static LogEventInfo BaseCreate(string application, LogLevel logLevel, string message, string logger)
        {
            var info = new LogEventInfo()
            {
                Level = logLevel,
                Message = message,
                LoggerName = logger
            };
            info.Properties["Applciation"] = application;
            return info;
        }
    }
}
