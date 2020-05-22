using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BugChang.Blog.Utility
{
    public static class HttpHelper
    {
        public static async Task<T> Get<T>(string url)
        {
            var content = await Get(url);
            return JsonConvert.DeserializeObject<T>(content);
        }

        public static async Task<string> Get(string url)
        {
            var http = new HttpClient();
            var responseMessage = await http.GetAsync(url);
            var content = await responseMessage.Content.ReadAsStringAsync();
            return content;
        }
    }
}
