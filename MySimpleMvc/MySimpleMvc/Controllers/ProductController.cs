using MySimpleMvc.Interface;
using System.Collections.Generic;
using System.Web;

namespace MySimpleMvc.Controllers
{
    public class ProductController : IController
    {
        private HttpContext currentContext;

        public void Index()
        {
            currentContext.Response.Write("Product Index!");
        }

        public void Add()
        {
            currentContext.Response.Write("Product Add!");
        }

        public void Execute(HttpContextWrapper wrapper)
        {
            currentContext = wrapper.context;
            IDictionary<string, string> routeData = wrapper.routeData;

            string actionName = "index";

            if (routeData.ContainsKey("{action}"))
            {
                actionName = routeData["{action}"];
            }

            switch (actionName.ToLower())
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