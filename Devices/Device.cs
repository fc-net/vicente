using System.Collections.Generic;
using Beesion.Recruitment.SeniorTest.Common;
using System.Linq;
using Beesion.Recruitment.SeniorTest.DevicesSpecifications;

namespace Beesion.Recruitment.SeniorTest.Devices
{
    public class Device : IProduct
    {
        public string Sku { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public virtual ICollection<DeviceSpecification> Specifications { get; set; }
        public string Description
        {
            get { return Specifications.Select(f => f.Feature).Aggregate((current, next) => current + ", " + next); }
            set { Description = value; }
        }
    }
}