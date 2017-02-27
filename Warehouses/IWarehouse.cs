using Beesion.Recruitment.SeniorTest.Devices;
using Bession.Recruitment.Application.Accesories;
using System.Collections.Generic;

namespace Beesion.Recruitment.SeniorTest.Warehouses
{
    public interface IWarehouse
    {
        IList<Warehouse> GetAll();
        IList<Warehouse> GetAll(IDevice device, IAccesoryService accesory);
    }
}