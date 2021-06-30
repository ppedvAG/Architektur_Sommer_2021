using NUnit.Framework;

namespace ppedv.MovieThemeCollector.Device.ACME.Tests
{
    public class ACMESoundplayer2000Tests
    {

        [Test]
        public void Can_play_sound()
        {
            var player =  new ACMESoundplayer2000();
            player.Play(280, 200);
            player.Play(120, 200);
        }
    }
}