using DynamicData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestingApplication.Helpers
{
    internal static class ReflectiveEnumerator
    {
        static ReflectiveEnumerator() { }
        public static IEnumerable<T> GetEnumerableOfType<T>(params object[] constructorArgs) where T : class, IComparable<T>
        {
            List<T> objects = new List<T>();
            var assembly = Assembly.GetAssembly(typeof(T));
            if (assembly != null) {
                foreach (Type type in assembly.GetTypes()
                    .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(T))))
                {
                    var instance = (T?)Activator.CreateInstance(type, constructorArgs);
                    if (instance != null)
                        objects.Add(instance);
                }
                objects.Sort();
            }
            return objects;
        }
    }
}
