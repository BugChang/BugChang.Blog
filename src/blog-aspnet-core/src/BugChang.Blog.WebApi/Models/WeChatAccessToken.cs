using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace BugChang.Blog.WebApi.Models
{
  
    public class WeChatAccessToken
    {

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
