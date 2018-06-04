using Microsoft.AspNetCore.Http;
using System;

namespace GardenCommunity.Web.Extensions
{
    public static class RequestExtension
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {

            var Reqyest = request ?? throw new ArgumentNullException("request");       
            if (request.Headers != null)
                return request.Headers["X-Requested-With"] == "XMLHttpRequest";
            return false;
        }
    }
}
