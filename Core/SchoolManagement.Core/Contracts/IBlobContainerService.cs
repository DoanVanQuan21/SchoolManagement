namespace SchoolManagement.Core.Contracts
{
    public interface IBlobContainerService
    {
        Task<bool> UploadImage(string filePath);
        Task GetContainer();
        Task<string> DownloadImage(string name);
        Task<Uri?> GetImage(string fileName);
    }
}