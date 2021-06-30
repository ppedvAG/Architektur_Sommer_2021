using ppedv.MovieThemeCollector.Contracts.Interfaces;
using System;

namespace ppedv.MovieThemeCollector.Logic
{
    public class Core_InjectionSamples
    {

        public Core_InjectionSamples(IDevice device) //ctor injection
        {

        }

        #region Property injection
        public IDevice Device { get; set; }

        public void PlaySound()
        {
            Device.Play(11, 11);
        }
        #endregion 

        public void PlaySound(IDevice dev) //method / manual injection
        {
        }
    }
}
