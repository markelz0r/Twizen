using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using Tizen.Multimedia;
using TwitchLib.Api.Helix.Models.Streams;
using Twizen.TV;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Timer = System.Timers.Timer;

namespace Twizen.Common
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TwitchPlayerPage : ContentPage
    {
        private TwitchPlayer _twitchPlayer;

        public TwitchPlayerPage(Stream stream)
        {
            InitializeComponent();
            Stream = stream;
            BindingContext = this;
            InitPlayer();
        }

        public Stream Stream { get; }

        private async void InitPlayer()
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync($"http://server.markel.info:3333/link/{Stream.UserName}");
            var dic = new Dictionary<string, string>();
            try
            {
                dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
            }
            catch (Exception ex)
            {
                // ignored
            }

#if TIZEN
            _twitchPlayer = new TwitchPlayer();
            _twitchPlayer.Start(dic["best"]);

            activityIndicator.IsRunning = false;
            activityIndicator.IsVisible = false;
#endif
            ShowUi();
        }

        private async void ShowUi()
        {
            TitleBar.IsVisible = true;
            PlayerControls.IsVisible = true;

            await Task.Delay(10000);
            HideUI();
        }

        private void HideUI()
        {
            TitleBar.IsVisible = false;
            PlayerControls.IsVisible = false;
        }

        protected override bool OnBackButtonPressed()
        {
            _twitchPlayer.Player.Stop();
            Navigation.PopModalAsync();

            _twitchPlayer.Player.Dispose();
            return true;
        }

        private void Pause_OnClicked(object sender, EventArgs e)
        {
            ShowUi();
            switch (_twitchPlayer.Player.State)
            {
                case PlayerState.Playing:
                    _twitchPlayer.Player.Pause();
                    return;
                case PlayerState.Paused:
                    _twitchPlayer.Player.Start();
                    return;
                case PlayerState.Idle:
                case PlayerState.Ready:
                case PlayerState.Preparing:
                default:
                    return;
            }
        }

        private void Quality_OnClicked(object sender, EventArgs e)
        {
            
        }
    }
}