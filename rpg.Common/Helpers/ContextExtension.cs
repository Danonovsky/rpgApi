using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace rpg.Common.Helpers
{
    public static class ContextExtension
    {
        public static Guid GetUserId(this IHttpContextAccessor httpContextAccessor)
        {
            var id = new Guid(httpContextAccessor.HttpContext.User.Claims.Where(_ => _.Type == "id").First().Value);
            return id;
        }
    }
}
