using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Script.Serialization;
using Beesion.Recruitment.SeniorTest.Services;

namespace Beesion.Recruitment.SeniorTest
{
    public class DefaultHandler : IHttpHandler
    {
        public bool IsReusable { get { return false; } }

        public void ProcessRequest(HttpContext context)
        {
            var serializer = new JavaScriptSerializer();
            var serviceName = context.Request["serviceName"];
            var operationName = context.Request["operationName"];

            try
            {
                var ops = ServiceDispatcher.GetOperation(serviceName, operationName);
                var parameters = new List<object>();
                int num = 0;
                foreach (var parameterInfo in ops.MethodInfo.GetParameters())
                {
                    ++num;
                    var input = context.Request["parameter" + num];
                    parameters.Add(serializer.Deserialize(input, parameterInfo.ParameterType));
                }
                var result = ops.MethodInfo.Invoke(ops.ServiceDescriptor.TargetInstance, parameters.ToArray());
                context.Response.ContentType = "text/json";
                context.Response.Write(new JavaScriptSerializer().Serialize(result));
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error executing {0}.{1}",serviceName, operationName),ex);
            }
        }
    }
}