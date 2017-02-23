using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beesion.Recruitment.SeniorTest.Devices
{
    public interface IDevice
    {
        IList<Device> GetAll();
        Device GetBySku(string sku);
    }
}