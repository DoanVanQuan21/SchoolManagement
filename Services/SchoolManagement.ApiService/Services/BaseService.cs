using Newtonsoft.Json;
using SchoolManagement.ApiService.Contracts;
using System.Net;

namespace SchoolManagement.ApiService.Services
{
    public abstract class BaseService : IBaseService
    {
        public async Task<TType> GetResponse<TType>(string apiUrl,string errorMessage=null)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TType>(responseBody);
                }
                catch (HttpRequestException e)
                {
                    errorMessage = e.Message;
                    return default(TType);
                }
            }
        }
    }
}