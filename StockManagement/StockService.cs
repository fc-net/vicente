using Beesion.Recruitment.SeniorTest.Services;
using System;
using Bession.Recruitment.Domain.Core.Repositories;
using Bession.Recruitment.Domain.Core.Contracts;
using Bession.Recruitment.Application.Core.DTOs;

namespace Beesion.Recruitment.SeniorTest.StockManagement
{
    [BusinessService]
    public class StockService
    {
        private readonly IStockLogic _stockLogic;
        private readonly IWarehouseRepository _warehouseRespository;
        public StockService(IStockLogic stockLogic, IWarehouseRepository warehouseRespository)
        {
            if (stockLogic == null)
                throw new ArgumentNullException();
            _stockLogic = stockLogic;

            if (warehouseRespository == null)
                throw new ArgumentNullException();
            _warehouseRespository = warehouseRespository;
        }

        [BusinessOperation]
        public StockReportDto GetStockReport(string productType, string productId)
        {
            var warehouse = _warehouseRespository.GetAll();
            var stock = _stockLogic.GetStockReport(warehouse, productType, productId);

            return stock;
        }
    }    
}