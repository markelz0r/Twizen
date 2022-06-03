using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using Tizen.Multimedia;
using Twizen.Common.TizenEvents;
using Twizen.TV;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Timer = System.Threading.Timer;

namespace Twizen.Common
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TwitchPlayerPage : ContentPage
    {
        private TwitchPlayer _twitchPlayer;
        private Timer _hideUiTimer;

        public TwitchPlayerPage(TwizenBroadcast broadcast)
        {
            InitializeComponent();
            Broadcast = broadcast;
            BindingContext = this;

            InitPlayer();
        }

        private void HideUiIn10Seconds(object state)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                TitleBar.IsVisible = false;
                PlayerControls.IsVisible = false;
            });
        }

        public TwizenBroadcast Broadcast { get; }

        private async void InitPlayer()
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync($"http://server.markel.info:3333/link/{Broadcast.Stream.UserName}");
            var dic = new Dictionary<string, string>();
            try
            {
                dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
            }
            catch (Exception ex)
            {
                // ignored
            }

            _twitchPlayer = new TwitchPlayer();

            //TODO make this safer since some streams might not have best option available
            _twitchPlayer.Start(dic["best"]);

            activityIndicator.IsRunning = false;
            activityIndicator.IsVisible = false;

            var autoEvent = new AutoResetEvent(false);
            _hideUiTimer = new Timer(HideUiIn10Seconds, autoEvent, 5000, Timeout.Infinite);

            InputEvents.GetEventHandlers(this).Add(new RemoteKeyHandler((args) =>
            {
                if (args.KeyName == RemoteControlKeyNames.Up)
                    ShowUi();
            }, RemoteControlKeyTypes.KeyUp));
        }

        private void ShowUi()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                TitleBar.IsVisible = true;
                PlayerControls.IsVisible = true;
                PlayPauseButton.Focus();
            });

            _hideUiTimer.Change(10000, Timeout.Infinite);
        }

        protected override bool OnBackButtonPressed()
        {
            _twitchPlayer?.Player.Stop();
            Navigation.PopModalAsync();

            _twitchPlayer?.Player.Dispose();
            return true;
        }

        private void Pause_OnClicked(object sender, EventArgs e)
        {
            ResetHideUiTimer();
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

        private void ResetHideUiTimer()
        {
            _hideUiTimer.Change(5000, Timeout.Infinite);
        }

        private void VisualElement_OnFocused(object sender, FocusEventArgs e)
        {
            //ResetHideUiTimer();
        }

        private void MainGrid_OnFocusChangeRequested(object sender, FocusRequestArgs e)
        {
            ShowUi();
        }
    }
}