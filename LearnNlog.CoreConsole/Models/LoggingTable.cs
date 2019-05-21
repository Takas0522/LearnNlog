using System;
using System.Collections.Generic;

namespace LearnNlog.CoreConsole.Models
{
    public partial class LoggingTable
    {
        public int Id { get; set; }
        public DateTime Logged { get; set; }
        public string Application { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string Logger { get; set; }
        public string ActionMethod { get; set; }
        public string Exception { get; set; }
        public string StackTrace { get; set; }
    }
}
