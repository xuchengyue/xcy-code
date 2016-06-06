using SimpleMvc_Lib.Routing;
using SimpleMvc_Lib.Mvc;
using System;

namespace SimpleMvc_App
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.routeList.MatchRoute("{controller}", new { controller = "home", action = "index" });
            RouteTable.routeList.MatchRoute("{controller}/{action}", new { controller = "home", action = "index" });
            RouteTable.routeList.MatchRoute("{controller}/{action}/{id}", new { controller = "home", action = "index" });
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}