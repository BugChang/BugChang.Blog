using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BugChang.Blog.WebApi.Models
{
    public class WeChatConfig
    {
        public string AppId { get; set; }

        public long Timestamp { get; set; }

        public string NonceStr { get; set; }

        public string Signature { get; set; }

        public string[] JsApiList { get; set; }
    }
}
