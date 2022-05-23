﻿using System;
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

        public TwitchPlayerPage()
        {
            InitializeComponent();
#if TIZEN
            InitPlayer();
#endif
        }

        private async void InitPlayer()
        {
            _player = await TwitchPlayer.CreateAndStart("https://sec.ch9.ms/ch9/5d93/a1eab4bf-3288-4faf-81c4-294402a85d93/XamarinShow_mid.mp4");
        }

        protected override bool OnBackButtonPressed()
        {
            _player.Stop();
            _player.Dispose();

            Navigation.PopModalAsync();
            return true;
        }
    }
}