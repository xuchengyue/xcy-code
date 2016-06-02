using MySimpleMvc.Interface;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.Compilation;

namespace MySimpleMvc.Handler
{
    /// <summary>
    /// MvcHandler 的摘要说明
    /// </summary>
    public class MvcHandler : IHttpHandler
    {
        // 路由表
        private IDictionary<string, string> routeData;
        //控制器类型集合
        private static IList<Type> allocationControllerTypes;

        static MvcHandler()
        {
            allocationControllerTypes = new List<Type>();
            // 获得当前所有引用的程序集
            var assemblies = BuildManager.GetReferencedAssemblies();

            foreach (Assembly item in assemblies)
            {
                var allTypes = item.GetTypes();

                foreach (Type type in allTypes)
                {
                    if (type.IsClass && !type.IsAbstract && type.IsPublic && typeof(IController).IsAssignableFrom(type))
                    {
                        allocationControllerTypes.Add(type);
                    }
                }
            }
        }

        public MvcHandler(IDictionary<string, string> routeData)
        {
            this.routeData = routeData;
        }

        public void ProcessRequest(HttpContext context)
        {
            var controllerName = routeData["{controller}"];

            if (string.IsNullOrEmpty(controllerName))
            {
                controllerName = "home";
            }

            IController controller = null;

            foreach (var controllerItem in allocationControllerTypes)
            {
                if (controllerItem.Name.Equals(string.Format("{0}Controller", controllerName), StringComparison.InvariantCultureIgnoreCase))
                {
                    controller = Activator.CreateInstance(controllerItem) as IController;
                }
            }

            var requestContext = new HttpContextWrapper()
            {
                context = context,
                routeData = routeData
            };

            controller.Execute(requestContext);
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