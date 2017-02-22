using System.Collections.Generic;
using Beesion.Recruitment.SeniorTest.Common;
using System.Linq;
using System;

namespace Beesion.Recruitment.SeniorTest.Devices
{
    public class Device : IProduct
    {
        public string Sku { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public List<DeviceSpecification> Specifications { get; set; }
        public string Description
        {
            get { return Specifications.Select(f => f.Feature).Aggregate((current, next) => current + ", " + next); }
            set { Description = value; }
        }
    }

    public class DeviceSpecification
    {
        public string Feature { get; set; }
        public string Comments { get; set; }
    }
}