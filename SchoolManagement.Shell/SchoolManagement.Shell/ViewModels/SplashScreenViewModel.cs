using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Models.SchoolManagements;
using System.Threading.Tasks;

namespace SchoolManagement.Shell.ViewModels
{
    internal class SplashScreenViewModel : BaseRegionViewModel
    {
        private string imagePath;
        private string loadingText;
        private int processValue = 0;

        public SplashScreenViewModel()
        {
            ImagePath = ".\\Assets\\resources\\images\\logo.png";
            LoadingText = "Loading...";
            InitApp().GetAwaiter();
        }

        public string ImagePath
        { get => imagePath; set { SetProperty(ref imagePath, value); } }

        public bool IsLoaded { get; set; } = false;

        public string LoadingText
        { get => loadingText; set { SetProperty(ref loadingText, value); } }

        public int ProcessValue
        { get => processValue; set { SetProperty(ref processValue, value); } }

        public override string Title => "Splass Screen";

        public override User User { get; protected set; }

        private async Task InitApp()
        {
            await Task.Delay(500);
            ProcessValue = 0;
            while (ProcessValue < 100)
            {
                ProcessValue++;
                LoadingText = $"Initializing the application {ProcessValue}%...";
                await Task.Delay(5);
            }
            IsLoaded = true;
        }
    }
}