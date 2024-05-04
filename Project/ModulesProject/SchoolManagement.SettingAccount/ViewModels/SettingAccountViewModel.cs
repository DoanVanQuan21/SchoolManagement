using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Helpers;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using Avalonia.Media.Imaging;
using System.Windows.Input;
using Avalonia.Controls;
using SchoolManagement.Core.Contracts;

namespace SchoolManagement.SettingAccount.ViewModels
{
    internal class SettingAccountViewModel : BaseRegionViewModel
    {
        private readonly IUserService _userService;
        private readonly IBlobContainerService _blobContainerService;
        private User user;
        private Bitmap? image;

        public SettingAccountViewModel()
        {
            _userService = Ioc.Resolve<IUserService>();
            _blobContainerService = Ioc.Resolve<IBlobContainerService>();
            User = new User(RootContext.CurrentUser);
            LoadImageAsync(null).GetAwaiter();
        }

        public ICommand ClickedUpdateInformation { get; set; }
        public ICommand ClickedChangeImage { get; set; }    
        public override string Title => "Tài khoản";
        public Bitmap? Image { get => image; set => SetProperty(ref image,value); }
        public override User User
        { get => user; protected set { SetProperty(ref user, value); } }
        private async Task LoadImageAsync(Uri uri)
        {
            if (uri == null)
            {
                Image = await ImageHelper.LoadImageFromResourse(User.Image);
                return;
            }
            Image = await ImageHelper.LoadFromWeb(uri);
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
            var uri = await _blobContainerService.GetImage("logo");
            User.Image = uri.AbsoluteUri;
            await LoadImageAsync(uri);
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