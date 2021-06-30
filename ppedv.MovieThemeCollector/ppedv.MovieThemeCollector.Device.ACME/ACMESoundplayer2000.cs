using System;

namespace ppedv.MovieThemeCollector.Device.ACME
{
    public class ACMESoundplayer2000
    {
        public void Play(int freq, int duration)
        {
            Console.Beep(freq, duration);
        }
    }
}
