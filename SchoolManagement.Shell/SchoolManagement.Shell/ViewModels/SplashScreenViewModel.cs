using SchoolManagement.Core.avalonia;
using System.Threading.Tasks;

namespace SchoolManagement.Shell.ViewModels
{
    internal class SplashScreenViewModel : BaseRegionViewModel
    {
        private string imagePath;
        private int processValue = 0;
        private string loadingText;

        public override string Title => "Splass Screen";

        public string ImagePath
        { get => imagePath; set { SetProperty(ref imagePath, value); } }

        public int ProcessValue
        { get => processValue; set { SetProperty(ref processValue, value); } }

        public string LoadingText
        { get => loadingText; set { SetProperty(ref loadingText, value); } }
        public bool IsLoaded { get; set; } = false;
        public SplashScreenViewModel()
        {
            ImagePath = ".\\Assets\\resources\\images\\logo.png";
            LoadingText = "Loading...";
            InitApp().GetAwaiter();
        }

        private async Task InitApp()
        {
            await Task.Delay(500);
            ProcessValue = 0;
            while (ProcessValue < 100)
            {
                ProcessValue ++;
                LoadingText = $"Initializing the application {ProcessValue}%...";
                await Task.Delay(50);

            }
            IsLoaded = true;
        }

    }
}