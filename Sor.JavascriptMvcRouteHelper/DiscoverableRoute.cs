﻿using System;
using System.Web.Routing;
using System.Web.Mvc;

namespace Sor.JavascriptMvcRouteHelper
{
    public class DiscoverableRoute : Route
    {
        public DiscoverableRoute(string url) : base(url, new MvcRouteHandler())
        {
            if (url.IndexOf("{action}", StringComparison.OrdinalIgnoreCase) > -1)
            {
                throw new ArgumentException("url may not contain the {action} parameter", "url");
            }
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            return null;
        }
    }
}
