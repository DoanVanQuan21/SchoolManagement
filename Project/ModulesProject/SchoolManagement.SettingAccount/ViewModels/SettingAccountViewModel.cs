using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Helpers;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using Avalonia.Media.Imaging;
using System.Windows.Input;
using Avalonia.Controls;

namespace SchoolManagement.SettingAccount.ViewModels
{
    internal class SettingAccountViewModel : BaseRegionViewModel
    {
        private readonly IUserService _userService;
        private User user;
        private Bitmap? image;

        public SettingAccountViewModel()
        {
            _userService = Ioc.Resolve<IUserService>();
            User = new User(RootContext.CurrentUser);
            LoadImageAsync().GetAwaiter();
        }

        public ICommand ClickedUpdateInformation { get; set; }
        public ICommand ClickedChangeImage { get; set; }    
        public override string Title => "Tài khoản";
        public Bitmap? Image { get => image; set => SetProperty(ref image,value); }
        public override User User
        { get => user; protected set { SetProperty(ref user, value); } }
        private async Task LoadImageAsync()
        {
            Image = await ImageHelper.LoadImageFromResourse(User.Image);
        }
        protected override void RegisterCommand()
        {
            ClickedUpdateInformation = new DelegateCommand(OnUpdateInfo);
            ClickedChangeImage = new DelegateCommand(OnChangeImage);
            base.RegisterCommand();
        }

        private async void OnChangeImage()
        {
            NotificationManager.ShowInfor("Change image");
            var topLevel = TopLevel.GetTopLevel(AppRegion.MainView);
            var files = await topLevel.StorageProvider.OpenFilePickerAsync(new Avalonia.Platform.Storage.FilePickerOpenOptions()
            {
                Title = "Chọn hình ảnh",
                FileTypeFilter = new[] {ImageHelper.ImageAll}
            });
            if(files == null || files.Count<=0)
            {
                return;
            }
            var file = files.FirstOrDefault();
            User.Image = file.Path.LocalPath;
            //await LoadImageAsync();
        }

        private void OnUpdateInfo()
        {
            var isUpdated = _userService.UpdateUserInfor(User);
            if (!isUpdated)
            {
                NotificationManager.ShowSuccess(Util.GetResourseString("UpdateUserFail_Message"));
                return;
            }
            UpdateCurrentUser(User);
            NotificationManager.ShowSuccess(Util.GetResourseString("UpdateUserSuccess_Message"));
        }
    }
}