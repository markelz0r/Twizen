using TizenTVHttpSample;
using Xamarin.Forms;
namespace Twizen.TV
{
    class Program : global::Xamarin.Forms.Platform.Tizen.FormsApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();

            LoadApplication(new App());
        }

        static void Main(string[] args)
        {
            var app = new Program();
            Forms.Init(app, true);
            app.Run(args);
        }
    }
}
