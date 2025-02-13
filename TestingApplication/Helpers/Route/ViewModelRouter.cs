using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.ViewModels;

namespace TestingApplication.Helpers.Route
{
    internal static class ViewModelRouter
    {
        public static void RegisterViewModels(RouteDirectory route)
        {
            var assembly = Assembly.GetAssembly(typeof(ViewModelBase));
            if (assembly != null)
            {
                foreach (Type type in assembly.GetTypes()
                    .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(ViewModelBase))))
                {
                    route.Register(type.Name!.Replace("ViewModel", ""), type);
                }
            }
        }
    }
}
