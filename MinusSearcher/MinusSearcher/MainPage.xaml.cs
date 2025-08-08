using SearcherCore;

namespace MinusSearcher
{
    public partial class MainPage : ContentPage
    {
        private PulseAnimator animator_;
        private CancellationTokenSource? cts_;
        public MainPage()
        {
            InitializeComponent();
            animator_ = new PulseAnimator(PulseButton,
                                          new List<VisualElement> { Wave1, Wave2});
        }

        private void OnPressed(object sender, EventArgs e)
        {
            if(cts_ != null)
            {
                cts_.Cancel();
                cts_.Dispose();
            }

            cts_ = new CancellationTokenSource();
            _= animator_.StartAsync(cts_.Token);
        }

        private void OnReleased(object sender, EventArgs e)
        {
            if (cts_ != null)
            {
                cts_.Cancel();
                cts_.Dispose();
                cts_ = null;
            }
        }
    }

}
