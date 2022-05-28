using Tizen.Multimedia;

using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;

namespace Twizen.TV
{
    public class TwitchPlayer
    {
        public Player Player { get; }
        public TwitchPlayer()
        {
            Player = new Player();
        }
        public async void Start(string contentUrl)
        {
            Player.SetSource(new MediaUriSource(contentUrl));
            var display = new Display(((FormsApplication)Forms.Context).MainWindow);

            Player.Display = display;

            await Player.PrepareAsync();
            Player.Start();

            if (Player.DisplaySettings.IsVisible == false)
            {
                Player.DisplaySettings.IsVisible = true;
            }

            Player.DisplaySettings.Mode = PlayerDisplayMode.FullScreen;
        }
    }
}