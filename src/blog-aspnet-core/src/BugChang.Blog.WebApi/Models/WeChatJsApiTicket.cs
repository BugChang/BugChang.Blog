using System;
using System.Text.Json.Serialization;

namespace BugChang.Blog.WebApi.Models
{
    [Serializable]
    public class WeChatJsApiTicket
    {
        [JsonPropertyName("errcode")]
        public int ErrorCode { get; set; }

        [JsonPropertyName("errmsg")]
        public string ErrMsg { get; set; }

        public string Ticket { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
    }
}
