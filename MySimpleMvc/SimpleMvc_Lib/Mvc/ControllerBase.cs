using System;
using System.Collections.Generic;
using System.Reflection;
using System.Web;

namespace SimpleMvc_Lib.Mvc
{
    public abstract class ControllerBase : IController
    {
        public HttpContext context;
        public IDictionary<string, string> routeData;

        public ActionResult Execute(RequestContext request)
        {
            context = request.rContext;
            routeData = request.routeData;
            string actionName = routeData["action"];

            var actions = this.GetType().GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            MethodInfo method = null;
            foreach (var action in actions)
            {
                if (action.Name.Equals(actionName, StringComparison.CurrentCultureIgnoreCase))
                {
                    method = action;
                    break;
                }
            }

            if (method == null)
            {
                throw new HttpException("404 not found!");
            }

            List<object> valueList = new List<object>();
            var paras = method.GetParameters();

            foreach (var item in paras)
            {
                string name = item.Name;
                Type type = item.ParameterType;

                string value = context.Request[name];

                if (string.IsNullOrEmpty(value))
                {
                    value = routeData.ContainsKey(name) ? routeData[name] : null;
                }

                if (!string.IsNullOrEmpty(value))
                {
                    valueList.Add(Convert.ChangeType(value, type));
                }
                else
                {
                    valueList.Add(null);
                }
            }

            ActionResult result = method.Invoke(this, valueList.ToArray()) as ActionResult;

            return result;
        }
    }
}
