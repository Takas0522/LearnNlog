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
            LoggingSettings.WriteLogToSqlDatabaseInit(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Logging;Integrated Security=True;", LogLevel.Error);
            WriteLog.Info("HOGE", "ConsoleApplication", "Main");
            WriteLog.Trace("FUGA", "ConsoleApplication", "Main");
            try
            {
                var a = 0;
                var b = 0;
                var c = a / b;
            }
            catch (Exception e)
            {
                WriteLog.Error("FUGA", "ConsoleApplication", "Main", e);
            }
            Console.WriteLine("HelloWorld");
        }
    }
}
