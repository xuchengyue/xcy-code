using System.Collections.Generic;

namespace SimpleMvc_Lib.Routing
{
    public static class RouteTable
    {
        public static IList<Route> routeList
        {
            get;
            set;
        }

        public static Route MatchRoutes(string requestUrl, out IDictionary<string, string> routeData)
        {
            routeData = null;
            foreach (Route route in routeList)
            {
                if (route.MatchUrl(requestUrl, out routeData))
                {
                    return route;
                }
            }
            return null;
        }
    }
}
