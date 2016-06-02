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
            IDictionary<string, string> route = new Dictionary<string, string>();
            //route = 
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
