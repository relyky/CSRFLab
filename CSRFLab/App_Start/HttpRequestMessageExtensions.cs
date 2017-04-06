using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace CSRFLab
{
    public static class HttpRequestMessageExtensions
    {
        public static bool IsAjaxRequest(this HttpRequestMessage req)
        {
            IEnumerable<string> headers;
            if (req.Headers.TryGetValues("X-Requested-with", out headers))
            {
                var header = headers.FirstOrDefault();
                if (!string.IsNullOrEmpty(header))
                {
                    return header.ToLowerInvariant() == "xmlhttprequest";
                }
            }
            return false;
        }
    } 
}