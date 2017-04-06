using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace CSRFLab
{
    public class AntiForgeryHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage req, CancellationToken cancellationToken)
        {
            string cookieToken = null;
            string formToken = null;
            if (req.IsAjaxRequest())
            {
                IEnumerable<string> tokenHeaders;
                if (req.Headers.TryGetValues("_RequestVerificationToken", out tokenHeaders))
                {
                    var cookie = req.Headers.GetCookies(AntiForgeryConfig.CookieName).FirstOrDefault();
                    if (cookie != null)
                    {
                        cookieToken = cookie[AntiForgeryConfig.CookieName].Value;
                    }
                    formToken = tokenHeaders.FirstOrDefault();
                }
            }
            try
            {
                if (cookieToken != null && formToken != null)
                {
                    AntiForgery.Validate(cookieToken, formToken);
                }
                else
                {
                    AntiForgery.Validate();
                }
            }
            catch (HttpAntiForgeryException)
            {
                return req.CreateResponse(HttpStatusCode.Forbidden);
            }

            return await base.SendAsync(req, cancellationToken);

        }
    } 
}