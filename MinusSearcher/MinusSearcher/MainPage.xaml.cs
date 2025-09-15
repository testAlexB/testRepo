using CommunityToolkit.Maui.Media;
using SearcherCore;
using System.Globalization;

namespace MinusSearcher
{
    public partial class MainPage : ContentPage
    {
        private PulseAnimator animator_;
        private CancellationTokenSource? cts_;
        private Task<string>? listenTask_;

        public MainPage()
        {
            InitializeComponent();
            animator_ = new PulseAnimator(PulseButton,
                                          new List<VisualElement> { Wave1, Wave2});


            //SpeechToText.Default.RecognitionResultCompleted += Default_RecognitionResultCompleted;
            //SpeechToText.Default.RecognitionResultUpdated += Default_RecognitionResultUpdated;
        }

        private async void OnPressed(object sender, EventArgs e)
        {
            cts_ = new CancellationTokenSource();
            _= animator_.StartAsync(cts_.Token);

            try
            {
                var speechService = SpeechToText.Default;

                if(!await speechService.RequestPermissions())
                {
                    await DisplayAlert("Ошибка", "Нет разрешений на микрофон", "ОК");
                    return;
                }

                var result = await speechService.ListenAsync(
                    CultureInfo.GetCultureInfo("ru-RU"),
                    null,
                    cts_.Token);

                ResultLabel.Text = result.Text;
            }
            catch(Exception ex)
            {
                await DisplayAlert("Ошибка", ex.Message, "ОК");
            }
        }

        private void OnReleased(object sender, EventArgs e)
        {
            //await SpeechToText.Default.StopListenAsync();

            if (listenTask_ != null)
            {
                listenTask_.Wait();
                string result = listenTask_.Result;
                if (!string.IsNullOrWhiteSpace(result))
                {
                    ResultLabel.Text = $"Сказал {result}";
                }
                else
                {
                    ResultLabel.Text = "Фиг знает, что сказал";
                }
            }

            if (cts_ != null)
            {
                cts_.Cancel();
                cts_.Dispose();
                cts_ = null;
            }
        }
    }

}

