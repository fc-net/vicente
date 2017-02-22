using System.Collections.Generic;
using Beesion.Recruitment.SeniorTest.Common;

namespace Beesion.Recruitment.SeniorTest.Devices
{
    public class Device : IProduct
    {
        public string Sku { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public List<DeviceSpecification> Specifications { get; set; }
    }

    public class DeviceSpecification
    {
        public string Feature { get; set; }
        public string Comments { get; set; }
    }
}