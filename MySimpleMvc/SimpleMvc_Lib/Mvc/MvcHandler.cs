using System.Collections.Generic;
using System.Web;
using System.Web.Compilation;

namespace SimpleMvc_Lib.Mvc
{
    public class MvcHandler : IHttpHandler
    {
        IDictionary<string, string> routeData;

        public MvcHandler(IDictionary<string, string> data)
        {
            routeData = data;
        }

        public void ProcessRequest(HttpContext context)
        {
            string controllerName = routeData["controller"];
            IController controller = DefaultControllerFactory.CreateController(controllerName);
            if (controller == null)
            {
                throw new HttpException("404 not found!");
            }
            RequestContext requestContext = new RequestContext()
                                                                 {
                                                                     rContext = context,
                                                                     routeData = routeData
                                                                 };
            ActionResult result = controller.Execute(requestContext);
            result.Execute(requestContext);
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}
