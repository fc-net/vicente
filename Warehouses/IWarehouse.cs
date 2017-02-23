using Beesion.Recruitment.SeniorTest.Accesories;
using Beesion.Recruitment.SeniorTest.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beesion.Recruitment.SeniorTest.Warehouses
{
    public interface IWarehouse
    {
        IList<Warehouse> GetAll();
        IList<Warehouse> GetAll(IDevice device, IAccesory accesory);
    }
}