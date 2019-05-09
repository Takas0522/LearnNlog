using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnNlog.Logging
{
    public static class LoggingSettings
    {
        // cf. http://m12i.hatenablog.com/entry/2016/11/26/220019
        // cf. http://hkou.hatenablog.com/entry/2016/03/13/194043
        // cf. http://d.hatena.ne.jp/Kazzz/20111105/p1
        private static readonly string LogLayout = "${longdate}|${event-properties:item=EventId.Id}|${logger}|${uppercase:${level}}|${message} ${exception}";
        static LoggingSettings()
        {
            var conf = new LoggingConfiguration();
            LogManager.Configuration = conf;

        }
        public static void ConsoleLogInit()
        {
            var conf = LogManager.Configuration;
            var console = new ConsoleTarget("console");
            console.Layout = LogLayout;
            conf.AddTarget(console);
            conf.LoggingRules.Add(new LoggingRule("*", LogLevel.Trace, console));
            LogManager.Configuration = conf;
        }
        public static void WriteLogFileInit(string filePath, LogLevel targetLogLevel)
        {
            var conf = LogManager.Configuration;
            var file = new FileTarget("file");
            file.Encoding = Encoding.UTF8;
            file.FileName = filePath;
            file.Layout = LogLayout;
            conf.AddTarget(file);
            conf.LoggingRules.Add(new LoggingRule("*", targetLogLevel, file));
            LogManager.Configuration = conf;
        }
        public static void WriteLogSqlDatabaseInit(string connectionString)
        {
            // cf. https://nlog-project.org/documentation/v2.0.1/html/T_NLog_Targets_DatabaseTarget.htm
            // cf. https://github.com/damienbod/AspNetCoreNlog
            var dbtarget = new DatabaseTarget();
            dbtarget.ConnectionString = connectionString;
            dbtarget.CommandText = "Inser Into LogTable(application)";
            
        }
    }
}
