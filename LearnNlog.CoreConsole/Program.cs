using System;
using LearnNlog.Logging;
using NLog;

namespace LearnNlog.CoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggingSettings.ConsoleLogInit();
            LoggingSettings.WriteLogFileInit("logfile.txt", LogLevel.Error);
            WriteLog.Info("HOGE");
            WriteLog.Trace("Fufa");
            WriteLog.Error("ERROR");
            Console.WriteLine("HelloWorld");
        }
    }
}
