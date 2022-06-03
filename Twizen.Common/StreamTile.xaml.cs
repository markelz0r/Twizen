﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using TwitchLib.Api.Helix.Models.Streams;
using Twizen.TV;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Twizen.Common
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class StreamTile : ContentView
   {
      private TwizenBroadcast _broadcast;
      private string _title;
      private string _thumbnailUrl;
      private string _viewerCount;
        private string _username;
        private Color _buttonTextColor;

        public StreamTile()
      {
         InitializeComponent();
         BindingContext = this;
      }

      public TwizenBroadcast Broadcast
      {
         get => _broadcast;
         set
         {
            _broadcast = value;
            OnPropertyChanged();
            GenerateFields();
         }
      }

      public string Title
      {
         get => _title;
         set
         {
            _title = value;
            OnPropertyChanged();
         }
      }

      public string ThumbnailUrl
      {
         get => _thumbnailUrl;
         set
         {
            _thumbnailUrl = value;
            OnPropertyChanged();
         }
      }

      public Color ButtonTextColor
        {
            get => _buttonTextColor;
            set
            {
                _buttonTextColor = value;
                OnPropertyChanged();
            }
        }

      public string ViewerCount
      {
         get => _viewerCount;
         set
         {
            _viewerCount = value;
            OnPropertyChanged();
         }
      }

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged();
            }
        }

        async void OnTapped(object sender, EventArgs e)
        {
            // TODO figure out how to get m3u8 from twitch
            await Navigation.PushModalAsync(new TwitchPlayerPage(Broadcast));
            //TwitchPlayer.Start("https://sec.ch9.ms/ch9/5d93/a1eab4bf-3288-4faf-81c4-294402a85d93/XamarinShow_mid.mp4");
        }

        private void GenerateFields()
      {
         Title = new string(Broadcast.Stream.Title.Take(30).ToArray());
         ThumbnailUrl = Broadcast.Stream.ThumbnailUrl.Replace("{width}", "480").Replace("{height}", "270");
         ViewerCount = Broadcast.Stream.ViewerCount.ToString();
         Username = Broadcast.Stream.UserName;
      }
    }
}