using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotleConvenience.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class TestController : Controller
    {
        [Authorize]
        public IActionResult Get()
        {
            return Ok("成功");
        }
    }
}