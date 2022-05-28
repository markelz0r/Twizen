using System.ComponentModel;
using Xamarin.Forms;

using Xamarin.Forms.Platform.Tizen;

[assembly: ExportEffect(typeof(Twizen.Common.FocusEffect), nameof(Twizen.Common.FocusEffect))]
namespace Twizen.Common
{ 
    internal class FocusEffect : PlatformEffect
    {
        Color focusColor = Color.FromHex("#ffffff");
        private Color originalColor = Color.FromHex("#212121");

        protected override void OnAttached()
        {
            (Element as Button).BackgroundColor = originalColor;
            (Element as Button).TextColor = Color.White;
        }

        protected override void OnDetached()
        {
            //throw new NotImplementedException();
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if (args.PropertyName == "IsFocused")
            {
                if ((Element as Button).BackgroundColor == focusColor)
                    {
                    (Element as Button).BackgroundColor = originalColor;
                    (Element as Button).TextColor = Color.White;
                    }
                else
                {
                    (Element as Button).BackgroundColor = focusColor;
                    (Element as Button).TextColor = Color.Black;
                }
                
            }                           
        }
    }
}