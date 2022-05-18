using System;
using System.Threading.Tasks;
using Tizen.Multimedia;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;

namespace Twizen.TV
{
   public class TwitchPlayer
   {
      private Player _player;

      public TwitchPlayer()
      {
         CreatePlayer();
      }

      private async Task CreatePlayer()
      {
         _player = new Player();

            _player.ErrorOccurred += OnError;

            _player.SetSource(new MediaUriSource("https://sec.ch9.ms/ch9/5d93/a1eab4bf-3288-4faf-81c4-294402a85d93/XamarinShow_mid.mp4"));
         var view = new MediaView(((FormsApplication)Forms.Context).MainWindow);
         var display = new Display(view);
         
         _player.Display = display;
         await PreparePlayer();
      }

        private void OnError(object sender, PlayerErrorOccurredEventArgs e)
        {
            System.Diagnostics.Debugger.Log(1, "Player", e.ToString());
        }

        private async Task PreparePlayer()
      {
         await _player.PrepareAsync();
         if (_player.DisplaySettings.IsVisible == false)
         {
            _player.DisplaySettings.IsVisible = true;
         }
         _player.DisplaySettings.Mode = PlayerDisplayMode.FullScreen;
         _player.Start();
         System.Diagnostics.Debugger.Log(1, "Player", "Player has started");
        }
   }
}