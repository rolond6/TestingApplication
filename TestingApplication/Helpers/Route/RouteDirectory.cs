using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApplication.Helpers.Route
{
    internal class RouteDirectory
    {
        private Dictionary<string, Type> _list = new Dictionary<string, Type>();

        public void Register(string name, Type type)
        {
            try
            {
                _list.Add(name, type);
            }
            catch
            {
                throw new RouteRegisterFailedException();
            }
        }

        public void Unregister(string name)
        {
            try
            {
                _list.Remove(name);
            }
            catch { }
        }

        public Type Get(string name) { 
            try
            {
                return _list[name];
            }
            catch
            {
                throw new RouteUnregisteredException();
            }
        }

        public void Clear() 
        { 
            _list.Clear(); 
        }
        public bool Contains(string name)
        {
            try
            {
                return _list.ContainsKey(name);
            }
            catch
            {
                return false;
            }
        }
        
    }
}
