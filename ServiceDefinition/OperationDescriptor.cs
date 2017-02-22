using System.Reflection;

namespace Beesion.Recruitment.SeniorTest.Services
{
    public class OperationDescriptor
    {
        public string Name { get; private set; }
        public MethodInfo MethodInfo { get; private set; }
        public ServiceDescriptor ServiceDescriptor { get; private set; }

        public OperationDescriptor(string name, MethodInfo methodInfo, ServiceDescriptor serviceDescriptor)
        {
            Name = name;
            MethodInfo = methodInfo;
            ServiceDescriptor = serviceDescriptor;
        }
    }
}