using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
using HanumanInstitute.MvvmDialogs.Avalonia;
using HanumanInstitute.MvvmDialogs.FileSystem;
using SchoolManagement.Core.avalonia;
using SchoolManagement.Core.Contracts;

namespace SchoolManagement.Core.Services
{
    public class StorageService : IStorageService
    {
        private readonly IAppManager _appManager;
        public StorageService()
        {
            _appManager = Ioc.Resolve<IAppManager>();   
        }
        protected virtual IStorageProvider Storage => _storage ??= GetTopLevel(Application.Current)?.StorageProvider ?? throw new NullReferenceException("No StorageProvider found.");
        private IStorageProvider? _storage;
        public async Task<IDialogStorageFolder> GetDownloadFolderAsync()
        {
            var result = await Storage.TryGetWellKnownFolderAsync(WellKnownFolder.Downloads);
            return result?.ToDialog();
        }
        private TopLevel GetTopLevel(Application? app)
        {
            if (app?.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                return TopLevel.GetTopLevel(_appManager.AppRegion?.MainView);
            }
            if (app?.ApplicationLifetime is ISingleViewApplicationLifetime viewApp)
            {
                var visualRoot = TopLevel.GetTopLevel(_appManager.AppRegion?.MainView);
                return visualRoot;
            }
            return null;
        }
    }
}