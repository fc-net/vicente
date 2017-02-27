using Beesion.Recruitment.Application;
using Beesion.Recruitment.SeniorTest.Devices;
using Beesion.Recruitment.SeniorTest.Services;
using Bession.Recruitment.Application;
using Bession.Recruitment.Application.Accesories;
using System;
using System.Collections.Generic;

namespace Beesion.Recruitment.SeniorTest.Warehouses
{
    [BusinessService]
    public class WarehouseService
    {
        private readonly IWarehouse _warehouse;
        private readonly IDevice _device;
        private readonly IAccesoryService _accesory;
        public WarehouseService(IWarehouse warehouse, IDevice device, IAccesoryService accesory)
        {
            if (warehouse == null)
                throw new ArgumentNullException();
            _warehouse = warehouse;

            if (device == null)
                throw new ArgumentNullException();
            _device = device;

            if (accesory == null)
                throw new ArgumentNullException();
            _accesory = accesory;
        }

        [BusinessOperation]
        public IList<WarehouseDto> GetAll()
        {
            var warehouses = _warehouse.GetAll(_device, _accesory);
            return GetWarehouseDto(warehouses);
        }

        [BusinessOperation]
        public IList<WarehouseDto> GetWarehouseDto(IList<Warehouse> warehouses)
        {
            var result = new List<WarehouseDto>();

            var name = "";
            foreach (var warehouse in warehouses)
            {
                name = warehouse.Name;
                foreach (var stockCount in warehouse.StockCounts)
                {
                    result.Add(new WarehouseDto
                    {
                        Name = name,
                        Brand = stockCount.Product.Brand,
                        Description = stockCount.Product.Description,
                        ProductType = stockCount.ProductType,
                        ProductId = stockCount.ProductId,
                        Quantity = stockCount.Quantity
                    });
                }
            }

            return result;
        }
    }
}