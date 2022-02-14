using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bupa.WebUI.Services
{
    public interface IApiService
    {
        Task<List<T>> GetList<T>(string path, string token = null);   // zaman kalırsa token ekle backend
        Task<T> Posts<T>(string path, T data, string token = null);
    }
}
