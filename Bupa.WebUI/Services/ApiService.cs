using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Bupa.WebUI.Services
{
    public class ApiService : IApiService
    {
        private IHttpContextAccessor _httpContextAccessor;
        public ApiService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        /// <summary>
        ///token eklenilmedi kullunabilir düşüncesi ile detaylı yapılmıştı
        ///o yüzden null yapıldı
        /// </summary>
        public async Task<List<T>> GetList<T>(string path, string token = null)
        {
            using (var client = new HttpClient())
            {
                List<T> resultDto = Activator.CreateInstance<List<T>>();

                client.BaseAddress = new Uri("http://localhost:5000/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(path);
                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var responseContainer = ((JContainer)JsonConvert.DeserializeObject(jsonData));
                    resultDto = JsonConvert.DeserializeObject<List<T>>(responseContainer.ToString());

                    Console.WriteLine(resultDto);
                }

                return resultDto;
            }
        }
        /// <summary>
        ///token eklenilmedi kullunabilir düşüncesi ile detaylı yapılmıştı
        ///o yüzden null yapıldı
        /// </summary>
        public async Task<T> Posts<T>(string path, T data, string token = null)
        {

            using (var client = new HttpClient())
            {
                T resultDto = Activator.CreateInstance<T>();
                client.BaseAddress = new Uri("http://localhost:5000/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string responseBody = String.Empty;
                string metaData = JsonConvert.SerializeObject(data).ToString();
                var method = new HttpMethod("POST");
                var request = new HttpRequestMessage(method, path)
                {
                    Content = new StringContent(metaData, encoding: Encoding.UTF8, "application/json")
                };

                using (HttpResponseMessage response = client.SendAsync(request).Result)
                {
                    response.EnsureSuccessStatusCode(); //başarısızlık durumlarını belirli bir şekilde ele almak istemediğinizde, bir isteğin başarısını kısaca doğrulama
                    responseBody = await response.Content.ReadAsStringAsync();
                    var responseContainer = ((JContainer)JsonConvert.DeserializeObject(responseBody));
                    resultDto = JsonConvert.DeserializeObject<T>(responseContainer.ToString());
                }
                return resultDto;
            }
        }
        public async Task<T> PostSade<T>(string path, T data, string token = null)
        {

            using (var client = new HttpClient())
            {
                T resultDto = Activator.CreateInstance<T>();
                client.BaseAddress = new Uri("http://localhost:5000/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string responseBody = String.Empty;
                string metaData = JsonConvert.SerializeObject(data).ToString();
                var method = new HttpMethod("POST");
                var request = new HttpRequestMessage(method, path)
                {
                    Content = new StringContent(metaData, encoding: Encoding.UTF8, "application/json")
                };

                using (HttpResponseMessage response = client.SendAsync(request).Result)
                {
                    response.EnsureSuccessStatusCode();
                    responseBody = await response.Content.ReadAsStringAsync();
                    var responseContainer = ((JContainer)JsonConvert.DeserializeObject(responseBody));
                    resultDto = JsonConvert.DeserializeObject<T>(responseContainer.ToString());
            
                }
                return resultDto;
            }
        }
    }
}
