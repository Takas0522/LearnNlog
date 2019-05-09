using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnNlog.Logging
{
    public static class WriteLog
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static void Trace(string message)
        {
            _logger.Trace(message);
        }

        public static void Debug(string message)
        {
            _logger.Debug(message);
        }

        public static void Info(string message)
        {
            _logger.Info(message);
        }

        public static void Warn(string message)
        {
            _logger.Warn(message);
        }

        public static void Error(string message)
        {
            _logger.Error(message);
        }

        public static void Fatal(string message)
        {
            _logger.Fatal(message);
        }
    }
}
