using NLog;
using NLog.Config;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Text;

namespace LearnNlog.Logging
{
    /*
     nlogは基本的にnlog.configってXMLファイルで設定するんだけど
     Web AppsのApplication設定とかでフレキシブルに変更できる構成にしたい…のでこんな構成にしている
     */

    public static class LoggingSettings
    {
        // cf. http://m12i.hatenablog.com/entry/2016/11/26/220019
        // cf. http://hkou.hatenablog.com/entry/2016/03/13/194043
        // cf. http://d.hatena.ne.jp/Kazzz/20111105/p1
        private static readonly string LogLayout = "${longdate}|${event-properties:item=Application}|${logger}|${uppercase:${level}}|${message} ${exception} ${exception:format=Message, Type, ToString:separator=*}";

        static LoggingSettings()
        {
            var conf = new LoggingConfiguration();
            NLog.Common.InternalLogger.LogFile = "internal-log.txt";
            NLog.Common.InternalLogger.LogLevel = LogLevel.Warn;
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
        public static void WriteLogToFileInit(string filePath, LogLevel targetLogLevel)
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
        public static void WriteLogToSqlDatabaseInit(string connectionString, LogLevel targetLogLevel)
        {
            var conf = LogManager.Configuration;

            // cf. https://nlog-project.org/documentation/v2.0.1/html/T_NLog_Targets_DatabaseTarget.htm
            // cf. https://github.com/damienbod/AspNetCoreNlog
            // cf. http://d.hatena.ne.jp/Kazzz/20111105/p1
            var dbtarget = new DatabaseTarget();
            dbtarget.ConnectionString = connectionString;
            dbtarget.Name = "dbtarget";
            dbtarget.DBProvider = "System.Data.SqlClient";
            dbtarget.CommandText = "Insert Into LoggingTable("
                 + "Logged,"
                 + "Application,"
                 + "Level,"
                 + "Message,"
                 + "Logger,"
                 + "ActionMethod,"
                 + "Exception,"
                 + "StackTrace"
                 + ") values ("
                 + "@logged,"
                 + "@application,"
                 + "@level,"
                 + "@message,"
                 + "@logger,"
                 + "@actionMethod,"
                 + "@exception,"
                 + "@stackTrace"
                 + ")";
            var loggedParam = new DatabaseParameterInfo();
            loggedParam.Name = "@logged";
            loggedParam.Layout = "${date}";
            dbtarget.Parameters.Add(loggedParam);

            var applicationParam = new DatabaseParameterInfo();
            applicationParam.Name = "@application";
            applicationParam.Layout = "${event-properties:item=Applciation}";
            dbtarget.Parameters.Add(applicationParam);

            var levelParam = new DatabaseParameterInfo();
            levelParam.Name = "@level";
            levelParam.Layout = "${level:uppercase=true}";
            dbtarget.Parameters.Add(levelParam);

            var messageParam = new DatabaseParameterInfo();
            messageParam.Name = "@message";
            messageParam.Layout = "${message}";
            dbtarget.Parameters.Add(messageParam);

            var loggerParam = new DatabaseParameterInfo();
            loggerParam.Name = "@logger";
            loggerParam.Layout = "${logger}";
            dbtarget.Parameters.Add(loggerParam);

            var actionMethodParam = new DatabaseParameterInfo();
            actionMethodParam.Name = "@actionMethod";
            actionMethodParam.Layout = "${event-properties:item=ActionMethod}";
            dbtarget.Parameters.Add(actionMethodParam);

            var exceptionParam = new DatabaseParameterInfo();
            exceptionParam.Name = "@exception";
            exceptionParam.Layout = "${exception:toString}";
            dbtarget.Parameters.Add(exceptionParam);

            var stackTraceParam = new DatabaseParameterInfo();
            stackTraceParam.Name = "@stackTrace";
            stackTraceParam.Layout = "${exception:format=Message, Type, ToString:separator=*}";
            dbtarget.Parameters.Add(stackTraceParam);

            conf.AddTarget(dbtarget);
            conf.LoggingRules.Add(new LoggingRule("*", targetLogLevel, dbtarget));
            LogManager.Configuration = conf;
        }
    }
}
