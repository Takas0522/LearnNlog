using System;
using LearnNlog.CoreConsole.Models;
using LearnNlog.Logging;
using NLog;
using System.Linq;

namespace LearnNlog.CoreConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggingSettings.ConsoleLogInit();
            LoggingSettings.WriteLogToFileInit("logfile.txt", LogLevel.Error);
            LoggingSettings.WriteLogToSqlDatabaseInit(@"Data Source=localhost;Initial Catalog=Logging;Integrated Security=True;", LogLevel.Error);
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
            using (var db = new LoggingContext())
            {
                var d = db.LoggingTable.Select(x => new { x.Id, x.Application });
                var list = d.ToList();
            }
        }
    }
}
