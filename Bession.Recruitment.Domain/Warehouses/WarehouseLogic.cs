using Bession.Recruitment.Domain.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bession.Recruitment.Domain.Entities.Accesory;
using Bession.Recruitment.Domain.Entities.Device;
using Bession.Recruitment.Domain.Entities.Warehouse;
using Bession.Recruitment.Domain.Core.Repositories;

namespace Bession.Recruitment.Domain.Warehouses
{
    public class WarehouseLogic : IWarehouseLogic
    {
        private readonly IDeviceLogic _devicesLogic;
        private readonly IAccesoryLogic _accesoryLogic;

        public WarehouseLogic(IDeviceLogic devicesLogic, IAccesoryLogic accesoryLogic)
        {
            if (devicesLogic == null)
                throw new ArgumentNullException();
            _devicesLogic = devicesLogic;

            if (accesoryLogic == null)
                throw new ArgumentNullException();
            _accesoryLogic = accesoryLogic;
        }

        public IList<Warehouse> GetAll(IQueryable<Warehouse> warehouse)
        {
            warehouse.ToList().ForEach(x =>
                x.StockCounts
                    .ForEach(i =>
                    {
                        var existAccesory = _accesoryLogic.GetByPartNumber(i.ProductId);
                        if (existAccesory == null)
                            i.Product = _devicesLogic.GetBySku(i.ProductId);
                        else
                            i.Product = existAccesory;
                    }));

            return warehouse.ToList();
        }
    }
}
