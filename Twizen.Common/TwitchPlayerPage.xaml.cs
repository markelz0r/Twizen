using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private Player _player;
        private string _username;

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
            Dictionary<string, string> dic = new Dictionary<string, string>();
            try
            {
                dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(result);
            }
            catch (Exception ex)
            {
                //global::Tizen.Log.Info("Crash", ex.Message);
            }
            //Debug.WriteLine(dictionary["best"]);
#if TIZEN

            _player = await TwitchPlayer.CreateAndStart(dic["best"]);
            activityIndicator.IsRunning = false;
            activityIndicator.IsVisible = false;
#endif
        }

        protected override bool OnBackButtonPressed()
        {
            _player.Stop();
            Navigation.PopModalAsync();
            
            _player.Dispose();
            return true;
        }
    }
}