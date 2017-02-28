using Beesion.Recruitment.SeniorTest.Services;
using System;
using System.Collections.Generic;
using Bession.Recruitment.Application.Core.DTOs;
using Bession.Recruitment.Domain.Core.Repositories;
using Bession.Recruitment.Domain.Core.Contracts;

namespace Beesion.Recruitment.SeniorTest.Warehouses
{
    [BusinessService]
    public class WarehouseService : IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRespository;
        private readonly IWarehouseLogic _warehouseLogic;

        public WarehouseService(IWarehouseRepository warehouseRespository, IWarehouseLogic warehouseLogic)
        {
            if (warehouseRespository == null)
                throw new ArgumentNullException();
            _warehouseRespository = warehouseRespository;

            if (warehouseLogic == null)
                throw new ArgumentNullException();
            _warehouseLogic = warehouseLogic;
        }

        [BusinessOperation]
        public IList<WarehouseDto> GetAll()
        {
            var warehouses = _warehouseRespository.GetAll();
            var warehouse = _warehouseLogic.GetAll(warehouses);

            return MapperWarehouse.GetWarehouseDto(warehouse);
        }
    }
}