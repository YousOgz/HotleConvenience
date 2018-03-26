using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HotleConvenience.Api.Filters
{
    public class AuthorizationResultFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            AuthorizeInvaild(context);
        }

        public void AuthorizeInvaild(AuthorizationFilterContext context) {
            if (!LegalClientInvaild())
            {
                context.Result = Return401UnAuthorized("非法客户端");
            }
        }

        /// <summary>
        /// 合法客户端验证
        /// </summary>
        /// <returns></returns>
        public bool LegalClientInvaild() {
            return true;
        }

        public JsonResult Return401UnAuthorized(string msg) {
            return new JsonResult
                (
                    new
                    {
                        code = 401,
                        msg = msg
                    }
                );
        }
    }
}
