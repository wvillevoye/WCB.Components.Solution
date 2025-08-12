using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WCB.Components
{
    public static class DependencyWBC
    {
        public static void AddWCB(this IServiceCollection services)
        {
            var types = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => typeof(IDependency).IsAssignableFrom(x) && x is { IsInterface: false, IsAbstract: false });

            foreach (var type in types)
            {
                var dependency = Activator.CreateInstance(type) as IDependency;
                dependency?.AddDependencies(services);
            }
        }
    }

    public interface IDependency
    {
        void AddDependencies(IServiceCollection services);
    }


}

