using System.Web.Mvc;

namespace Sor.JavascriptMvcRouteHelper
{
    public class DiscoverableController : Controller
    {
        protected override IActionInvoker CreateActionInvoker()
        {
            return new DiscoverableControllerActionInvoker();
        }

        protected override void ExecuteCore()
        {
            if (ControllerContext.RouteData.Route is DiscoverableRoute)
            {
                ActionInvoker.InvokeAction(ControllerContext, "DiscoverControllerActions");
            }
            else
            {
                base.ExecuteCore();
            }
        }
    }
}
