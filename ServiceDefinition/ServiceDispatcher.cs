using System;
using System.Collections.Generic;
using System.Linq;

namespace Beesion.Recruitment.SeniorTest.Services
{
    public class ServiceDispatcher
    {
        private static Dictionary<string, ServiceDescriptor> services;

        public static OperationDescriptor GetOperation(string serviceName, string operationName)
        {
            if (services == null)
                services = BuildServicesMap();
            if (!services.ContainsKey(serviceName))
                throw new Exception(string.Format("Unable to find a business service with name {0}",serviceName));
            var sd = services[serviceName];
            if(!sd.Operations.ContainsKey(operationName))
                throw new Exception(string.Format("Unable to find a business operation with name {0}", operationName));
            return sd.Operations[operationName];
        }

        private static Dictionary<string, ServiceDescriptor> BuildServicesMap()
        {
            var result = new Dictionary<string, ServiceDescriptor>();
            foreach(var asm in AppDomain.CurrentDomain.GetAssemblies().Where(s => s.FullName.StartsWith("Beesion")))
            {
                foreach (var t in asm.GetTypes().Where(t => t.GetCustomAttributes(typeof(BusinessServiceAttribute), true).Length > 0))
                {
                    var sd = new ServiceDescriptor(t, Activator.CreateInstance(t));
                    foreach (var mInfo in t.GetMethods().Where(m => m.GetCustomAttributes(typeof(BusinessOperationAttribute), true).Length > 0))
                    {
                        var od = new OperationDescriptor(mInfo.Name, mInfo, sd);
                        sd.Operations[od.Name] = od;
                    }
                    result[t.Name] = sd;
                }
            }
            return result;
        }
    }
}