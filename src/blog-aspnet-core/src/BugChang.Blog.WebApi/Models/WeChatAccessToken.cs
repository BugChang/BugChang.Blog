using System;
using System.Text.Json.Serialization;

namespace BugChang.Blog.WebApi.Models
{
    [Serializable]
    public class WeChatAccessToken
    {

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
