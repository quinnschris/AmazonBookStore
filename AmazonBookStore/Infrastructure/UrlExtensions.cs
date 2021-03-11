using System;
using Microsoft.AspNetCore.Http;

namespace AmazonBookStore.Infrastructure
{
    public static class UrlExtensions
    {
        //Used to generate a return url

        public static string PathAndQuery(this HttpRequest request) =>
            request.QueryString.HasValue ? $"{request.Path}{request.QueryString}" : request.Path.ToString();
    }
}
