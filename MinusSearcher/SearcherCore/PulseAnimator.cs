namespace SearcherCore
{
    // All the code in this file is included in all platforms.
    public class PulseAnimator
    {
        private VisualElement target_; /// центральный круг
        private List<VisualElement> waves_; /// волны
        private CancellationToken token_;

        public PulseAnimator(VisualElement targetObj,
                             List<VisualElement> waves)
        {
            target_ = targetObj;
            waves_ = waves;
        }

        public async Task StartAsync(CancellationToken token)
        {
            token_ = token;

            _ = AnimatePulse(token_);

            _ = AnimateWavesLoop(token_);

            while(!token_.IsCancellationRequested)
            {
                await Task.Delay(100, token_);
            }
        }

        private async Task AnimatePulse(CancellationToken token)
        {
            while(!token.IsCancellationRequested)
            {
                await target_.ScaleTo(1.15, 300, Easing.SinInOut);
                await target_.ScaleTo(1.0, 300, Easing.SinInOut);
            }
        }

        private async Task AnimateWavesLoop(CancellationToken token)
        {
            int waveIndex = 0;

            while (!token.IsCancellationRequested)
            {
                var wave = waves_[waveIndex % waves_.Count];
                await AnimateWave(wave, 2.0, 1200);

                waveIndex++;
                await Task.Delay(100, token);
            }
        }

        private async Task AnimateWave(VisualElement wave, double scale, uint duration)
        {
            wave.Scale = 1;
            wave.Opacity = 1;
            wave.IsVisible = true;

            await Task.WhenAll(
                wave.ScaleTo(scale, duration, Easing.SinOut),
                wave.FadeTo(0, duration, Easing.SinOut)
            );

            wave.IsVisible = false;
        }
    }
}
