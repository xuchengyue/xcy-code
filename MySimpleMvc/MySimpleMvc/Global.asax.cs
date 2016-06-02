using MySimpleMvc.Handler;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MySimpleMvc
{
    public class Global : System.Web.HttpApplication
    {
        private static IList<string> Routes;
        protected void Application_Start(object sender, EventArgs e)
        {
            Routes = new List<string>();

            Routes.Add("{controller}/{action}");
            Routes.Add("{controller}");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            var executePath = Request.AppRelativeCurrentExecutionFilePath;
            if (string.IsNullOrEmpty(executePath) || executePath.Equals("~/"))
            {
                executePath += "/home/index";
            }

            var paraArray = executePath.Substring(2).Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            #region 做法一

            string controllerName = "home";
            string actionName = "index";
            //if (executePath.Equals("~/") || paraArray.Length == 0)
            if (paraArray.Length != 0 && !string.IsNullOrEmpty(paraArray[0]))
            {
                if (paraArray.Length > 0)
                {
                    controllerName = paraArray[0];
                }

                if (paraArray.Length > 1)
                {
                    actionName = paraArray[1];
                }
            }

            Context.RewritePath(string.Format("~/Handler/Index.ashx?controller={0}&action={1}", controllerName, actionName));
            #endregion

            #region 做法二:模拟路由表实现映射服务

            // 模拟路由字典
            IDictionary<string, string> routeData = new Dictionary<string, string>();


            foreach (var item in Routes)
            {
                var routeKeys = item.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                if (paraArray.Length == routeKeys.Length)
                {
                    for (int i = 0; i < routeKeys.Length; i++)
                    {
                        routeData.Add(routeKeys[i], paraArray[i]);
                        break;
                    }
                }
            }

            Context.RemapHandler(new MvcHandler(routeData));

            #endregion
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