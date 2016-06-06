using SimpleMvc_Lib.Routing;
using System.Collections.Generic;

namespace SimpleMvc_Lib.Mvc
{
    public static class RouteExtend
    {
        public static void MatchRoute(this  IList<Route> list, string template, object defaults)
        {
            list.Add(new Route(template,defaults));
        }
    }
}
