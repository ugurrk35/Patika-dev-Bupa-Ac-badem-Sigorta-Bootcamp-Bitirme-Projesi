using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bupa.Admin.Services
{
   public interface IApi
    {
        Task<List<T>> GetList<T>(string path, string token = null);   // zaman kalırsa token ekle backend
        Task<T> Posts<T>(string path, T data, string token = null);
    }
}
