using Beesion.Recruitment.SeniorTest.Accesories;
using Beesion.Recruitment.SeniorTest.Common;
using Beesion.Recruitment.SeniorTest.Devices;
using Beesion.Recruitment.SeniorTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beesion.Recruitment.SeniorTest.Warehouses
{
    [BusinessService]
    public class WarehouseService
    {
        [BusinessOperation]
        public IList<WarehouseDto> GetAll()
        {
            var warehouses = WarehouseRepository.GetAll();
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

        public class WarehouseDto : IProduct
        {
            public string Name { get; set; }
            public string Brand { get; set; }
            public string Description { get; set; }
            public string ProductType { get; set; }
            public string ProductId { get; set; }
            public int Quantity { get; set; }
        }
    }
}