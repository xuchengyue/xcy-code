using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Web.Compilation;

namespace SimpleMvc_Lib.Mvc
{
    public static class DefaultControllerFactory
    {
        private static IList<Type> AllTypes { get; set; }

        static DefaultControllerFactory()
        {
            AllTypes = new List<Type>();
            var assemblies = BuildManager.GetReferencedAssemblies();
            foreach (Assembly assembly in assemblies)
            {
                var types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    if (type.IsClass && !type.IsAbstract && type.IsPublic&& typeof(IController).IsAssignableFrom(type))
                    {
                        AllTypes.Add(type);
                    }
                }
            }
        }

        public static IController CreateController(string controllerName)
        {
            IController controller = null;
            foreach (var item in AllTypes)
            {
                if (item.Name.Equals(string.Format("{0}Controller", controllerName), StringComparison.CurrentCultureIgnoreCase))
                {
                    controller = Activator.CreateInstance(item) as IController;
                    break;
                }
            }
            return controller;
        }
    }
}
