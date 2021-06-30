using Serilog;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppedv.MovieThemeCollector.Common
{
    class Serilogger : Contracts.ILogger
    {
        public Serilogger()
        {
            Log.Logger = new LoggerConfiguration()
                               .WriteTo.File("serilog.txt")
                               .CreateLogger();
        }

        public void Error(string message)
        {
            Log.Logger.Error(message);
        }

        public void Info(string message)
        {
            Log.Logger.Information(message);
        }

        public void Warn(string message)
        {
            Log.Logger.Warning(message);
        }
    }
}
