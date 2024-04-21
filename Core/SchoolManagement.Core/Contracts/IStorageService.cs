using HanumanInstitute.MvvmDialogs.FileSystem;

namespace SchoolManagement.Core.Contracts
{
    public interface IStorageService
    {
        Task<IDialogStorageFolder> GetDownloadFolderAsync();
    }
}