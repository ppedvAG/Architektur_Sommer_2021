using System;

namespace HalloSingelton
{
    public class Logger
    {

        private static Logger instance = null;
        private static object _syncObj = new object();

        public static Logger Instance
        {
            get
            {
                lock (_syncObj)
                {
                    if (instance == null)
                        instance = new Logger();
                }
                return instance;
            }
        }

        static int instanceCount = 0;
        private Logger()
        {
            Log($"Logger #{++instanceCount} startet");
        }

        public void Log(string msg)
        {
            Console.WriteLine($"[{DateTime.Now}] {msg}");
        }
    }
}
