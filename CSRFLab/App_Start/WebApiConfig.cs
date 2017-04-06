using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSRFLab
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 設定和服務

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // 註冊 Web API 的 Anti-Forgery 檢查
            config.MessageHandlers.Add(new CSRFLab.AntiForgeryHandler());
        }
    }
}
