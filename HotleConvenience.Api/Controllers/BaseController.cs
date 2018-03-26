using HotleConvenience.Lib.Cache;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotleConvenience.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Base")]
    public class BaseController : Controller
    {
        private HttpContext _httpContext;
        private ICache _cache;
        public BaseController(HttpContext httpContext, ICache cache)
        {
            _httpContext = httpContext;
            _cache = cache;
        }

        public string Token
        {
            get
            {
                if (_httpContext.Request.Headers.TryGetValue("token", out var token))
                {
                    return token;
                }
                return null;
            }
        }

        public string CurrentUser
        {
            get
            {
                //未实现
                return null;
            }
        }
    }
}