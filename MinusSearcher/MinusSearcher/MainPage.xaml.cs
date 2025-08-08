namespace MinusSearcher
{
    public partial class MainPage : ContentPage
    {
        private bool isPulsing_ = false;
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnPressed(object sender, EventArgs e)
        {
            isPulsing_ = true;
            _ = StartPulseAnimation();
            await StartWaveLoop();
        }

        private async void OnReleased(object sender, EventArgs e)
        {
            isPulsing_ = false;

            await PulseButton.ScaleTo(1, 200, Easing.CubicOut);
        }

        private async Task StartPulseAnimation()
        {
            while(isPulsing_)
            {
                await PulseButton.ScaleTo(1.15, 300, Easing.SinInOut);
                await PulseButton.ScaleTo(1.0, 300, Easing.SinInOut);
            }
        }

        private async Task StartWaveLoop()
        {
            int waveIndex = 0;

            while(isPulsing_)
            {
                if (waveIndex % 2 == 0)
                    _ = AnimateWave(Wave1, 3, 1000);
                else
                    _ = AnimateWave(Wave2, 4, 1200);

                waveIndex++;
                await Task.Delay(500);
            }
        }

        private async Task AnimateWave(Border wave, double scale, uint duration)
        {
            wave.Opacity = 1;
            wave.IsVisible = true;

            await Task.WhenAll(
                wave.ScaleTo(scale, duration, Easing.SinOut),
                wave.FadeTo(0, duration, Easing.SinOut)
            );
            wave.Opacity = 0;
            wave.IsVisible = false;
        }
    }

}
