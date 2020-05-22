using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BugChang.Blog.Utility;
using BugChang.Blog.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;


namespace BugChang.Blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class WeChatController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _clientFactory;
        private readonly IMemoryCache _memoryCache;

        public WeChatController(IConfiguration configuration, IHttpClientFactory clientFactory, IMemoryCache memoryCache)
        {
            _configuration = configuration;
            _clientFactory = clientFactory;
            _memoryCache = memoryCache;
        }



        public async Task<IActionResult> JsApiTicket()
        {
            var cacheKey = "wechat_jsapi_ticket";
            if (_memoryCache.TryGetValue(cacheKey, out object value))
            {
                return Ok(value);
            }
            var accessToken = await AccessToken();
            var url = $"https://api.weixin.qq.com/cgi-bin/ticket/getticket?access_token={accessToken}&type=jsapi";
            var request = new HttpRequestMessage(HttpMethod.Get,
                url);
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                StreamReader reader = new StreamReader(responseStream);
                string text = reader.ReadToEnd();
                _memoryCache.Set(cacheKey, text, DateTimeOffset.Now.AddSeconds(7200));
                return Ok(text);
            }
            return BadRequest(response.Content);
        }

        private async Task<WeChatAccessToken> GetWeChatAccessToken()
        {
            var cacheKey = "wechat_access_token";
            if (_memoryCache.TryGetValue(cacheKey, out WeChatAccessToken value))
            {
                return value;
            }
            var appid = _configuration.GetSection("WeChatSettings:AppId").Value;
            var secret = _configuration.GetSection("WeChatSettings:Secret").Value;
            var url = $"https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={appid}&secret={secret}";
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

        private async Task<string> GetSignature()
        {
            var randomString = StringHelper.GetRandomString(16, false, true, true, false, "");
            var jsTicket = (await GetWeChatJsApiTicket()).Ticket;
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var url = "http://mp.weixin.qq.com?params=value";
            var dic = new Dictionary<string, object>
            {
                {"noncestr", randomString},
                {"jsapi_ticket", jsTicket},
                {"timestamp", timestamp},
                {"url", url}
            };
            var list = new List<string>();
            foreach (var d in dic)
            {
                list.Add($"{d.Key}={d.Value}");
            }

            var string1= string.Join('&',list);

        }
    }
}
