using ppedv.MovieThemeCollector.Common;
using System;

namespace ppedv.MovieThemeCollector.Device.ACME
{
    public class ACMESoundplayer2000
    {
        public void Play(int freq, int duration)
        {
            Logger.Instance.Info("ACMESoundplayer2000");
            Console.Beep(freq, duration);
        }
    }
}
