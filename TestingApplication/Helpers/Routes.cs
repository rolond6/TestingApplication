using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TestingApplication.ViewModels;

namespace TestingApplication.Helpers
{
    internal class Routes
    {
        private Dictionary<string, Type> _list = new Dictionary<string, Type>();

        public void RegisterViewModels()
        {
            var assembly = Assembly.GetAssembly(typeof(ViewModelBase));
            if (assembly != null)
            {
                foreach (Type type in assembly.GetTypes()
                    .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(ViewModelBase))))
                {
                    RegisterViewModel(type.Name!.Replace("ViewModel", ""), type);
                }
            }
        }
        public void RegisterViewModel(string name,Type type)
        {
            _list.Add(name, type);
        }
        public Type GetViewModel(string name)
        {
            return _list[name];
        }
    }
}
