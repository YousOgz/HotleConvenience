using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotleConvenience.Infrastructure.Auth;
using HotleConvenience.Lib.Cache;
using HotleConvenience.Lib.WeSmallApp;
using Microsoft.AspNetCore.Mvc;

namespace HotleConvenience.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        private CustomTokenProvider _customTokenProvider;
        private SmallAppClient _smallAppClient;
        private ICache _cache;
        public AccountController(CustomTokenProvider customTokenProvider,
                                 SmallAppClient smallAppClient,
                                 ICache cache) {
            _customTokenProvider = customTokenProvider;
            _smallAppClient = smallAppClient;
            _cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> GetTokenWithSmallApp(string code)
        {
            var keyInfo = await _smallAppClient.GetKeyInfo(code);
            if (keyInfo.open_id == null)
            {
                return BadRequest("获取token失败");
            }
            var token = _customTokenProvider.GetToken();
            _cache.AddOrUpdate("token",token.access_token);
            return Ok(token);
        }
    }
}