using Tizen.Multimedia;

#if TIZEN5_5
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
#endif

namespace Twizen.TV
{
    public class TwitchPlayer
    {
        public TwitchPlayer()
        {

        }
#if TIZEN5_5
        public static async void CreateAndStart(string contentUrl)
        {
            var player = new Player();

            //player.ErrorOccurred += OnError;

            player.SetSource(new MediaUriSource(contentUrl));
            var display = new Display(((FormsApplication)Forms.Context).MainWindow);

            player.Display = display;

            await player.PrepareAsync();
            if (player.DisplaySettings.IsVisible == false)
            {
                player.DisplaySettings.IsVisible = true;
            }

            player.DisplaySettings.Mode = PlayerDisplayMode.FullScreen;
            System.Diagnostics.Debugger.Log(1, "Player", "Player has started");
            player.Start();
        }

#else
        public static void CreateAndStart()
        {

        }
#endif
        private void OnError(object sender, PlayerErrorOccurredEventArgs e)
        {
            System.Diagnostics.Debugger.Log(1, "Player", e.ToString());
        }
    }
}