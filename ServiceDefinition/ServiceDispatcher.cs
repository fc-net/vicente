using Autofac;
using Beesion.Recruitment.SeniorTest.Accesories;
using Beesion.Recruitment.SeniorTest.Devices;
using Beesion.Recruitment.SeniorTest.Warehouses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Beesion.Recruitment.SeniorTest.Services
{
    public class ServiceDispatcher
    {
        private static Dictionary<string, ServiceDescriptor> services;
        public static IContainer Container { get; set; }

        public static OperationDescriptor GetOperation(string serviceName, string operationName)
        {
            Autofac();
            if (services == null)
                services = BuildServicesMap();
            if (!services.ContainsKey(serviceName))
                throw new Exception(string.Format("Unable to find a business service with name {0}", serviceName));
            var sd = services[serviceName];
            if (!sd.Operations.ContainsKey(operationName))
                throw new Exception(string.Format("Unable to find a business operation with name {0}", operationName));
            return sd.Operations[operationName];
        }

        private static Dictionary<string, ServiceDescriptor> BuildServicesMap()
        {
            var result = new Dictionary<string, ServiceDescriptor>();
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies().Where(s => s.FullName.StartsWith("Beesion")))
            {
                foreach (var t in asm.GetTypes().Where(t => t.GetCustomAttributes(typeof(BusinessServiceAttribute), true).Length > 0))
                {
                    object[] parameter = GetParametersConstructor(t);

                    var sd = new ServiceDescriptor(t, Activator.CreateInstance(t, parameter));
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

        private static object[] GetParametersConstructor(Type t)
        {
            var parametersConstructor = t.GetConstructors().FirstOrDefault().GetParameters();
            object[] parameter = new object[parametersConstructor.Count()];
            Type type;

            for (int i = 0; i < parameter.Count(); i++)
            {
                type = parametersConstructor[i].ParameterType;
                parameter[i] = Container.Resolve(type);
            }

            return parameter;
        }

        private static void Autofac()
        {
            // Create the builder with which components/services are registered.
            var builder = new ContainerBuilder();

            // Register types that expose interfaces...
            builder.RegisterType<WarehouseRepository>().As<IWarehouse>();
            builder.RegisterType<DevicesRepository>().As<IDevice>();
            builder.RegisterType<AccesoriesRepository>().As<IAccesory>();
            
            // Build the container to finalize registrations
            // and prepare for object resolution.
            Container = builder.Build();
        }
    }
}