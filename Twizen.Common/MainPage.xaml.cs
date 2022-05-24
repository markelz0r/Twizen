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
        private readonly TwitchAPI _api;

        public MainPage()
        {
            InitializeComponent();

            _api = new TwitchAPI
            {
                Settings =
                {
                    ClientId = "ocgrw1sbpatkypfrml0o9mj1zdbsz6",
                    AccessToken = "syfsf1kgfmatkdg73cqbk4npxafc5p"
                }
            };

            //_api = new TwitchAPI();

            LoadStreams();
        }

        private async void LoadStreams()
        {
            var streams = await _api.Helix.Streams.GetStreamsAsync();
            foreach (var stream in streams.Streams)
            {
                var streamTile = new StreamTile
                {
                    Stream = stream
                };

                StreamTiles.Children.Add(streamTile);
            }

            activityIndicator.IsRunning = false;
            activityIndicator.IsVisible = false;
        }
    }
}