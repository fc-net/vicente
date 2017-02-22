using System;
using System.Collections.Generic;

namespace Beesion.Recruitment.SeniorTest.Services
{
    public class ServiceDescriptor
    {
        public Type ServiceType { get; private set; }
        public object TargetInstance { get; private set; }
        public Dictionary<string, OperationDescriptor> Operations { get; private set; }
        
        public ServiceDescriptor(Type serviceType, object targetInstance)
        {
            ServiceType = serviceType;
            TargetInstance = targetInstance;
            Operations = new Dictionary<string, OperationDescriptor>();
        }
    }
}