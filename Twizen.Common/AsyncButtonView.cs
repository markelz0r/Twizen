using TwitchLib.Api.Helix.Models.Streams;
using Xamarin.Forms;

namespace Twizen.Common
{
    public class AsyncButtonView : ContentView
    {
        public static readonly BindableProperty ButtonCornerRadiusProperty = BindableProperty.Create(nameof(ButtonCornerRadius), typeof(int), typeof(AsyncButtonView), 0);
        public static readonly BindableProperty ButtonHasShadowProperty = BindableProperty.Create(nameof(ButtonHasShadow), typeof(bool), typeof(AsyncButtonView), false);
        public static readonly BindableProperty ButtonClippedToBoundsProperty = BindableProperty.Create(nameof(ButtonClippedToBounds), typeof(bool), typeof(AsyncButtonView), false);
        public static readonly BindableProperty ButtonBackgroundColorProperty = BindableProperty.Create(nameof(ButtonBackgroundColor), typeof(Color), typeof(AsyncButtonView), Color.White);
        public static readonly BindableProperty ButtonTextColorProperty = BindableProperty.Create(nameof(ButtonTextColor), typeof(Color), typeof(AsyncButtonView), Color.Black);
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(AsyncButtonView), string.Empty);
        public static readonly BindableProperty ThumbnailUrlProperty = BindableProperty.Create(nameof(ThumbnailUrl), typeof(string), typeof(AsyncButtonView), string.Empty);
        public static readonly BindableProperty ViewerCountProperty = BindableProperty.Create(nameof(ViewerCount), typeof(string), typeof(AsyncButtonView), "0");
        public static readonly BindableProperty UsernameProperty = BindableProperty.Create(nameof(Username), typeof(string), typeof(AsyncButtonView), string.Empty);
        
        
        public int ButtonCornerRadius
        {
            get => (int)GetValue(ButtonCornerRadiusProperty);
            set => SetValue(ButtonCornerRadiusProperty, value);
        }
        public bool ButtonHasShadow
        {
            get => (bool)GetValue(ButtonHasShadowProperty);
            set => SetValue(ButtonHasShadowProperty, value);
        }
        public bool ButtonClippedToBounds
        {
            get => (bool)GetValue(ButtonClippedToBoundsProperty);
            set => SetValue(ButtonClippedToBoundsProperty, value);
        }
        public Color ButtonBackgroundColor
        {
            get => (Color)GetValue(ButtonBackgroundColorProperty);
            set => SetValue(ButtonBackgroundColorProperty, value);
        }
        public Color ButtonTextColor
        {
            get => (Color)GetValue(ButtonTextColorProperty);
            set => SetValue(ButtonTextColorProperty, value);
        }
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public string ThumbnailUrl
        {
            get => (string)GetValue(ThumbnailUrlProperty);
            set => SetValue(ThumbnailUrlProperty, value);
        }

        public string ViewerCount
        {
            get => (string)GetValue(ViewerCountProperty);
            set => SetValue(ViewerCountProperty, value);
        }

        public string Username
        {
            get => (string)GetValue(UsernameProperty);
            set => SetValue(UsernameProperty, value);
        }
    }
}
