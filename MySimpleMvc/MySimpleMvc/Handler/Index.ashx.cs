using MySimpleMvc.Controllers;
using MySimpleMvc.Interface;
using System.Web;

namespace MySimpleMvc.Handler
{
    /// <summary>
    /// Index 的摘要说明
    /// </summary>
    public class Index : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var controllerName = context.Request.QueryString["controller"];

            if (string.IsNullOrEmpty(controllerName))
            {
                controllerName = "home";
            }

            IController controller;
            switch (controllerName)
            {
                case "home":
                    controller = new HomeController();
                    break;
                case "product":
                    controller = new ProductController();
                    break;
                default:
                    controller = new HomeController();
                    break;
            }

            //controller.Execute(context);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}