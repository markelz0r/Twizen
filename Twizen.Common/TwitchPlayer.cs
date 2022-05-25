using Tizen.Multimedia;

#if WINDOWS_UWP
using Windows.UI.Popups;
#endif

#if TIZEN5_5
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
#endif

namespace Twizen.TV
{
    public class TwitchPlayer
    {
        public Player Player { get; }
        public TwitchPlayer()
        {
            Player = new Player();
        }
#if TIZEN
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

#elif WINDOWS_UWP
        public static System.Threading.Tasks.Task<Player> Start(string contentUrl)
        {
            _ = new MessageDialog($"Twitch Player is starting up for {contentUrl}").ShowAsync();
            return null;
        }
#else
        public static async System.Threading.Tasks.Task<Player> Start(string contentUrl)
        {
            return null;
        }
#endif
        private void OnError(object sender, PlayerErrorOccurredEventArgs e)
        {
            System.Diagnostics.Debugger.Log(1, "Player", e.ToString());
        }
    }
}