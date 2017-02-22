using System;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using Qoollo.Net.Http.Attributes;
using SharpHttpServerTests;

namespace Qoollo.Net.Http
{
    public class AutoRouter
    {
        public static void AddControllerActions(object controller, HttpServer server)
        {
            Attribute attribute = Attribute.GetCustomAttribute(controller.GetType(), typeof(ControllerAttribute));
            if (attribute == null)
            {
                throw new InvalidOperationException("Class " + controller.GetType() + " does not have a ControllerAttribute.");            
            }

            ControllerAttribute controllerAttribute = attribute as ControllerAttribute;
                        
            // ReSharper disable once PossibleNullReferenceException
            if (controllerAttribute.ControllerRoute == null)
            {
                controllerAttribute.ControllerRoute = "/" + controller.GetType().Name.Replace("Controller", "");
            }

            MethodInfo[] methods = controller.GetType()
                .GetMethods()
                .Where(y => y.GetCustomAttributes(true).OfType<RouteAttribute>().Any())
                .ToArray();

            foreach (var method in methods)
            {
                RouteAttribute routeAttribute = method.GetCustomAttribute<RouteAttribute>();
                if (routeAttribute.Path == null)
                {
                    routeAttribute.Path = method.Name;
                }

                if(method.ReturnType == typeof(string) && method.GetParameters().Length == 1 && method.GetParameters()[0].ParameterType == typeof(HttpListenerRequest))
                    server.GetRegistrator(routeAttribute.HttpMethod)[controllerAttribute.ControllerRoute + "/" + routeAttribute.Path] =
                        (Func<HttpListenerRequest, string>)
                        Delegate.CreateDelegate(typeof(Func<HttpListenerRequest, string>), controller, method);
            }
        }
    }
}