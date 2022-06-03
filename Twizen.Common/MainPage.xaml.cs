using System.Collections.Generic;
using System.Linq;
using TwitchLib.Api;
using Twizen.Common;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TizenTVHttpSample
{
    /// <summary>
    /// MainPage Class
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            LoadStreams();
        }

        private async void LoadStreams()
        {
            var streams = await ApiProvider.Api.Helix.Streams.GetStreamsAsync();
            var userIds = streams.Streams.Select(s => s.UserId).ToList();
            var usersResponse = await ApiProvider.Api.Helix.Users.GetUsersAsync(userIds);
            foreach (var stream in streams.Streams)
            {
                var user = usersResponse.Users.Single(u => u.Id == stream.UserId);
                var twizenBroadcast = new TwizenBroadcast(stream, user);
                var streamTile = new StreamTile
                {
                    Broadcast = twizenBroadcast
                };

                StreamTiles.Children.Add(streamTile);
            }

            StreamTiles.Children.First().Focus();

            activityIndicator.IsRunning = false;
            activityIndicator.IsVisible = false;
        }
    }
}