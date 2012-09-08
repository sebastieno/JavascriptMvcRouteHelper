using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;

namespace Sor.JavascriptMvcRouteHelper
{
    public class DiscoverableControllerActionInvoker : ControllerActionInvoker
    {
        public override bool InvokeAction(ControllerContext controllerContext, string actionName)
        {
            if (controllerContext.RouteData.Route is DiscoverableRoute && actionName == "DiscoverControllerActions")
            {
                return RenderJavaScriptProxyScript(controllerContext);
            }

            return base.InvokeAction(controllerContext, actionName);
        }

        private bool RenderJavaScriptProxyScript(ControllerContext controllerContext)
        {
            ControllerDescriptor controllerDescriptor = GetControllerDescriptor(controllerContext);
            ActionDescriptor[] actions = controllerDescriptor.GetCanonicalActions();
            Dictionary<string, string> urls = new Dictionary<string, string>();

            foreach (ActionDescriptor action in actions)
            {
                if (!urls.ContainsKey(action.ActionName))
                {
                    string actionUrl = RouteTable.Routes.GetVirtualPath(controllerContext.HttpContext.Request.RequestContext, new RouteValueDictionary(new { controller = controllerDescriptor.ControllerName, action = action.ActionName })).VirtualPath;

                    urls.Add(action.ActionName, actionUrl);
                }
            }

            var serializer = new JavaScriptSerializer();
            var actionMethodNames = serializer.Serialize(urls);

            string proxyScript = @"if (typeof $mvc === 'undefined') {{ $mvc = {{}}; }} 
$mvc.{0} = {1};";

            proxyScript = String.Format(proxyScript, controllerDescriptor.ControllerName, actionMethodNames);

            controllerContext.HttpContext.Response.ContentType = "text/javascript";
            controllerContext.HttpContext.Response.Write(proxyScript);

            return true;
        }
    }
}
