using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;

namespace FactoryX.Web.ViewComponents
{
    /// <summary>
    /// 语言切换器视图组件
    /// </summary>
    public class LanguageSwitcherViewComponent : ViewComponent
    {
        /// <summary>
        /// 调用视图组件
        /// </summary>
        /// <returns>语言切换器视图</returns>
        public IViewComponentResult Invoke()
        {
            var currentCulture = Request.Cookies[CookieRequestCultureProvider.DefaultCookieName];
            var returnUrl = Request.Path + Request.QueryString;
            
            // 解析当前文化
            string culture = "zh-CN"; // 默认中文
            if (!string.IsNullOrEmpty(currentCulture))
            {
                try
                {
                    var requestCulture = CookieRequestCultureProvider.ParseCookieValue(currentCulture);
                    if (requestCulture != null && requestCulture.Cultures.Count > 0)
                    {
                        culture = requestCulture.Cultures[0].Value;
                    }
                }
                catch
                {
                    // 如果解析失败，使用默认值
                }
            }
            
            ViewBag.CurrentCulture = culture;
            ViewBag.ReturnUrl = returnUrl;
            
            return View();
        }
    }
}
