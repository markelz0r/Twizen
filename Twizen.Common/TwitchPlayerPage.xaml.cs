using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Tizen.Multimedia;
using Twizen.TV;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Twizen.Common
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TwitchPlayerPage : ContentPage
    {
        private string _username;
        private TwitchPlayer _twitchPlayer;

        public TwitchPlayerPage(string username)
        {
            InitializeComponent();
            _username = username;    
            InitPlayer();

        }

        private async void InitPlayer()
        {
            var client = new HttpClient();
            var result = await client.GetStringAsync($"http://server.markel.info:3333/link/{_username}");
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

        }

        protected override bool OnBackButtonPressed()
        {
            _twitchPlayer.Player.Stop();
            Navigation.PopModalAsync();

            _twitchPlayer.Player.Dispose();
            return true;
        }
    }
}