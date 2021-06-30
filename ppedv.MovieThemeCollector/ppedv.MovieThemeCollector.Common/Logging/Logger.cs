using ppedv.MovieThemeCollector.Contracts;

namespace ppedv.MovieThemeCollector.Common
{
    public class Logger 
    {
        private static ILogger instance = null;
        private static object _sync = new object();
        public static ILogger Instance
        {
            get
            {
                lock (_sync)
                {
                    if (instance == null)
                        instance = new Serilogger();
                        //instance = new TraceLogger();
                }
                return instance;
            }
        }
    }
}
