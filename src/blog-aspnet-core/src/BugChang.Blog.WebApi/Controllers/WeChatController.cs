using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using BugChang.Blog.Utility;
using BugChang.Blog.WebApi.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace BugChang.Blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class WeChatController : Controller
    {
        private readonly ILogger<WeChatController> _logger;
        private readonly IMemoryCache _memoryCache;
        private readonly string _appId;
        private readonly string _secret;
        public WeChatController(IConfiguration configuration, IMemoryCache memoryCache, ILogger<WeChatController> logger)
        {
            _memoryCache = memoryCache;
            _logger = logger;
            _appId = configuration.GetSection("WeChatSettings:AppId").Value;
            _secret = configuration.GetSection("WeChatSettings:Secret").Value;
        }



        [HttpGet("ShareConfig")]
        public async Task<IActionResult> Config(string url)
        {
            var nonceStr = StringHelper.GetRandomString(16, true, true, true, false, null);

            var weChatConfig = new WeChatConfig
            {
                AppId = _appId,
                JsApiList = new[] { "updateAppMessageShareData", "updateTimelineShareData" },
                NonceStr = nonceStr,
                Signature = await GetSignature(url, nonceStr),
                Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds()
            };
            return Ok(weChatConfig);
        }

        private async Task<WeChatAccessToken> GetWeChatAccessToken()
        {
            var cacheKey = "wechat_access_token";
            if (_memoryCache.TryGetValue(cacheKey, out WeChatAccessToken value))
            {
                return value;
            }
            var url = $"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={_appId}&secret={_secret}";
            var accessToken = await HttpHelper.Get<WeChatAccessToken>(url);
            _memoryCache.Set(cacheKey, accessToken, DateTimeOffset.Now.AddSeconds(7200));
            return accessToken;
        }

        private async Task<WeChatJsApiTicket> GetWeChatJsApiTicket()
        {
            var cacheKey = "wechat_jsapi_ticket";
            if (_memoryCache.TryGetValue(cacheKey, out WeChatJsApiTicket value))
            {
                return value;
            }
            var accessToken = await GetWeChatAccessToken();
            var url = $"https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={accessToken.AccessToken}&type=jsapi";
            var jsApiTicket = await HttpHelper.Get<WeChatJsApiTicket>(url);
            _memoryCache.Set(cacheKey, jsApiTicket, DateTimeOffset.Now.AddSeconds(7200));
            return jsApiTicket;
        }

        private async Task<string> GetSignature(string url, string nonceStr)
        {
            var jsTicket = (await GetWeChatJsApiTicket()).Ticket;
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            _logger.LogInformation("url：" + url);
            var dic = new Dictionary<string, object>
            {
                {"jsapi_ticket", jsTicket},
                {"noncestr", nonceStr},
                {"timestamp", timestamp},
                {"url", url}
            };
            var list = new List<string>();
            foreach (var d in dic)
            {
                list.Add($"{d.Key}={d.Value}");
            }
            var string1 = string.Join('&', list);
            _logger.LogInformation("string1结果：" + string1);
            var signature = string1.Sha1();
            _logger.LogInformation("微信签名结果：" + signature);
            return signature;
        }


    }
}
