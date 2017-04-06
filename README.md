# CSRFLab - Anti-Forgery
* ASP.NET Web API2 - CSRF-Cross-Site Request Forgery
* ref → [水煮 ASP.NET Web API2 方法論（1-7）CSRF-Cross-Site Request Forgery](http://xpower2888.pixnet.net/blog/post/221971901-%5B%E6%B0%B4%E7%85%AE-asp.net-web-api2-%E6%96%B9%E6%B3%95%E8%AB%96%5D%EF%BC%881-7%EF%BC%89csrf-cross-site-)
* ref → [Getting Started With ASP.Net Web API 2 : Day 8](http://www.c-sharpcorner.com/UploadFile/736ca4/getting-started-with-Asp-Net-web-api-2-day-8/)
* ref → [ASP.NET MVC 防範 CSRF 攻擊 - 在 AJAX 裡使用 AntiForgeryToken 的處理](http://kevintsengtw.blogspot.tw/2013/09/aspnet-mvc-csrf-ajax-antiforgerytoken.html)

## 重點
1. 建立 HttpRequestMessageExtensions 擴增新函式 IsAjaxRequest 檢查是否為 ajax 呼叫 
>     public static bool IsAjaxRequest(this HttpRequestMessage req)
2. 建立檢查 Anti-Forgery 的函式
>     public class AntiForgeryHandler: DelegatingHandler
3. 透過 Global.asax.cs 註冊檢查 Anti-Forgery 的函式，於 [\App_Start\WebApiConfig.cs]
>     config.MessageHandlers.Add(new AntiForgeryHandler());
4. Client 部份用 Razer 加入AntiForgeryToken
>     @Html.AntiForgeryToken()
5. 若呼叫 ajax 函式別忘了 header 也要加入 AntiForgeryToken
>     headers: {
>          "_RequestVerificationToken": $("#jsData input[name='__RequestVerificationToken']").val()
>     },
