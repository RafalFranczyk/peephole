using MediaManager;
using MediaManager.Library;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Peephole.HLS
{
    public partial class MainPage : ContentPage
    {
        readonly string HLS_URL = "https://devstreaming-cdn.apple.com/videos/streaming/examples/bipbop_16x9/bipbop_16x9_variant.m3u8";
        //readonly string HLS_URL = "https://multiplatform-f.akamaihd.net/i/multi/will/bunny/big_buck_bunny_,640x360_400,640x360_700,640x360_1000,950x540_1500,.f4v.csmil/master.m3u8";

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CrossMediaManager.Current.MediaPlayer.AutoAttachVideoView = true;
            _ = PlayVideo();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _ = StopVideo();
        }

        private async Task PlayVideo()
        {
            var item = await CrossMediaManager.Current.Extractor.CreateMediaItem(HLS_URL);
            item.MediaType = MediaType.Hls;

            await CrossMediaManager.Current.Play(item);
        }
        private async Task StopVideo()
        {
            await CrossMediaManager.Current.Stop();
        }
    }
}
