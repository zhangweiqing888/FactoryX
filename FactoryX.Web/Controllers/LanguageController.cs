using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

namespace FactoryX.Web.Controllers
{
    /// <summary>
    /// 语言切换控制器
    /// </summary>
    public class LanguageController : Controller
    {
        /// <summary>
        /// 切换语言
        /// </summary>
        /// <param name="culture">文化代码</param>
        /// <param name="returnUrl">返回URL</param>
        /// <returns>重定向到指定页面</returns>
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }

        /// <summary>
        /// 获取当前语言
        /// </summary>
        /// <returns>当前语言信息</returns>
        [HttpGet]
        public IActionResult GetCurrentLanguage()
        {
            var culture = Request.Cookies[CookieRequestCultureProvider.DefaultCookieName];
            return Json(new { culture = culture ?? "zh-CN" });
        }
    }
}
