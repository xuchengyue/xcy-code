using SimpleMvc_Lib.Mvc;
using System;
using System.Collections.Generic;
using System.Web;

namespace SimpleMvc_Lib.Routing
{
    public class UrlRoutingModule : IHttpModule
    {

        public void Init(HttpApplication context)
        {
            context.PostResolveRequestCache += Application_PostResolveRequestCache;
        }

        public void Application_PostResolveRequestCache(object sender, EventArgs e)
        {
            var application = sender as HttpApplication;
            var context = application.Context;

            string path = context.Request.AppRelativeCurrentExecutionFilePath.Substring(2);
            IDictionary<string, string> routeData = new Dictionary<string, string>();
            var route = RouteTable.MatchRoutes(path, out routeData);
            if (route == null)
            {
                throw new HttpException("404 not found!");
            }
            if (!routeData.ContainsKey("{controller}"))
            {
                throw new HttpException("404 not found!");
            }

            context.RemapHandler(new MvcHandler(routeData));
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
