using ppedv.MovieThemeCollector.Common;
using ppedv.MovieThemeCollector.Contracts.Interfaces;
using System;

namespace ppedv.MovieThemeCollector.Device.ACME
{
    public class ACMESoundplayer2000 : IDevice
    {
        public void Play(int freq, int dur)
        {
            PlayTheSoundWithTheDevice(freq * 2, dur / 2); //adapter
        }

        public void PlayTheSoundWithTheDevice(int freq, int duration)
        {
            Logger.Instance.Info("ACMESoundplayer2000");
            Console.Beep(freq, duration);
        }
    }
}
