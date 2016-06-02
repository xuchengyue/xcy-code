using MySimpleMvc.Interface;
using System.Collections.Generic;
using System.Web;

namespace MySimpleMvc.Controllers
{
    public class HomeController : IController
    {
        private HttpContext currentContext;

        public void Index()
        {
            currentContext.Response.Write("Home Index!");
        }

        public void Add()
        {
            currentContext.Response.Write("Home Add!");
        }

        public void Execute(HttpContextWrapper wrapper)
        {
            currentContext = wrapper.context;
            IDictionary<string, string> routeData = wrapper.routeData;

            string actionName = "index";

            if (routeData.ContainsKey("{action}"))
            {
                actionName = routeData["{actioin}"];
            }

            switch(actionName.ToLower())
            {
                case "index":
                    this.Index();
                    break;
                case "add":
                    this.Add();
                    break;
                default:
                    this.Index();
                    break;
            }
        }
    }
}