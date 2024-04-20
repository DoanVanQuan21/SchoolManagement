using System.Collections.ObjectModel;

namespace SchoolManagement.ApiService.Contracts
{
    public interface IBaseService
    {
        Task<TType> GetResponse<TType>(string apiUrl,string errorMessage = null);
    }
}