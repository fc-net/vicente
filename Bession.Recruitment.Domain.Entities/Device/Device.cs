using Bession.Recruitment.Domain.Entities.DevicesSpecifications;
using System.Collections.Generic;
using System.Linq;

namespace Bession.Recruitment.Domain.Entities.Device
{
    public class Device : IProduct
    {
        public string Sku { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public virtual ICollection<DeviceSpecification> Specifications { get; set; }
        public string Description
        {
            get { return GetDescription(); }
            set { Description = value; }
        }

        private string GetDescription()
        {
            return Specifications.Select(f => f.Feature).Aggregate((current, next) => current + ", " + next);
        }
    }
}
