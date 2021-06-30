using ppedv.MovieThemeCollector.Contracts;
using System;
using System.Diagnostics;
using System.Globalization;

namespace ppedv.MovieThemeCollector.Common
{
    class TraceLogger : ILogger
    {
        public TraceLogger()
        {
            Trace.Listeners.Add(new TextWriterTraceListener("tracelog.txt"));
            Trace.AutoFlush = true;
        }


        private static string GetText(string message, string lvl)
        {
            return $"[{lvl}] ({DateTime.Now.ToString(new CultureInfo("de"))}) {message}";
        }

        public void Error(string message)
        {
            Trace.WriteLine(GetText(message, "ERROR"));
        }

        public void Info(string message)
        {
            Trace.WriteLine(GetText(message, "INFO"));

        }

        public void Warn(string message)
        {
            Trace.WriteLine(GetText(message, "WARN"));
        }
    }
}
