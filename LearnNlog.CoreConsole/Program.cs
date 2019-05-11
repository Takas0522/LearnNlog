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
            LoggingSettings.WriteLogToFileInit("logfile.txt", LogLevel.Error);
            LoggingSettings.WriteLogToSqlDatabaseInit(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Logging;Integrated Security=True;", LogLevel.Warn);
            WriteLog.Info("HOGE");
            WriteLog.Trace("Fufa");
            WriteLog.Error("ERROR");
            Console.WriteLine("HelloWorld");
        }
    }
}
