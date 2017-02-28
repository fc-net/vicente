using Bession.Recruitment.Application.Core.DTOs;
using Bession.Recruitment.Domain.Entities.StockEntries;
using Bession.Recruitment.Domain.Entities.Warehouse;
using System.Collections.Generic;

namespace Beesion.Recruitment.SeniorTest.Warehouses
{
    public static class MapperWarehouse
    {
        internal static List<WarehouseDto> GetWarehouseDto(IList<Warehouse> listWarehouse)
        {
            var warehouseDto = new List<WarehouseDto>();
            var name = "";

            foreach (var currentEntity in listWarehouse)
            {
                name = currentEntity.Name;
                foreach (var stockCount in currentEntity.StockCounts)
                {
                    warehouseDto.Add(ToDto(stockCount, name));
                }
            }

            return warehouseDto;
        }

        internal static WarehouseDto ToDto(StockEntry stockEntity, string name)
        {
            WarehouseDto dto = new WarehouseDto()
            {
                Name = name,
                Brand = stockEntity.Product.Brand,
                Description = stockEntity.Product.Description,
                ProductType = stockEntity.ProductType,
                ProductId = stockEntity.ProductId,
                Quantity = stockEntity.Quantity
            };

            return dto;
        }
    }
}