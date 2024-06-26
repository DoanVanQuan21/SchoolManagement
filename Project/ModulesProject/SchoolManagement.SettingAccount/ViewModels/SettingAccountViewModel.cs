﻿using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Prism.Commands;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Context;
using SchoolManagement.Core.Contracts;
using SchoolManagement.Core.Helpers;
using SchoolManagement.Core.Models.SchoolManagements;
using SchoolManagement.EntityFramework.Contracts.IServices;
using SchoolManagement.SettingAccount.Views.Dialogs;
using System.Windows.Input;

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
            User.UpdateImage();
        }

        public ICommand ClickedUpdateInformation { get; set; }
        public ICommand ClickedChangeImage { get; set; }
        public ICommand ClickedChangePassword { get; set; }
        public override string Title => Util.GetResourseString("AccountSettings_Label");
        public Bitmap? Image { get => image; set => SetProperty(ref image, value); }

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
            ClickedChangePassword = new DelegateCommand(OnChangePassword);
            base.RegisterCommand();
        }

        private async void OnChangePassword()
        {
            var changePasswordView = new ChangePasswordView();
            changePasswordView.SetChangePasswordEvent(ChangePassword);
            await ShowDialogHost(changePasswordView);
        }

        private async void ChangePassword(User user)
        {
            RootContext.CurrentUser.Password = user.Password;
            var isChanged = await _userService.ChangePassword(RootContext.CurrentUser);
            if (!isChanged)
            {
                NotificationManager.ShowWarning(Util.GetResourseString("ChangePasswordError_Message"));
                return;
            }
            NotificationManager.ShowSuccess(Util.GetResourseString("ChangePasswordSuccess_Message"));
            CloseDialog();
        }

        private async void OnChangeImage()
        {
            NotificationManager.ShowInfor("Change image");
            var topLevel = TopLevel.GetTopLevel(AppRegion.MainView);
            var files = await topLevel.StorageProvider.OpenFilePickerAsync(new Avalonia.Platform.Storage.FilePickerOpenOptions()
            {
                Title = "Chọn hình ảnh",
                FileTypeFilter = new[] { ImageHelper.ImageAll }
            });
            if (files == null || files.Count <= 0)
            {
                return;
            }
            var file = files.FirstOrDefault();
            //var uri = await _blobContainerService.GetImage("logo");
            //User.Image = uri.AbsoluteUri;
            //await LoadImageAsync(uri);
            User.UpdateImage();
        }

        private async void OnUpdateInfo()
        {
            try
            {
                var isUpdated = await _userService.UpdateUserInfor(User);
                if (!isUpdated)
                {
                    NotificationManager.ShowSuccess(Util.GetResourseString("UpdateUserFail_Message"));
                    return;
                }
                UpdateCurrentUser(User);
                NotificationManager.ShowSuccess(Util.GetResourseString("UpdateUserSuccess_Message"));
            }
            catch (Exception ex)
            {
                NotificationManager.ShowError(ex.Message, 5);
            }
        }
    }
}