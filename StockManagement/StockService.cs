using Beesion.Recruitment.SeniorTest.Services;
using Beesion.Recruitment.SeniorTest.Warehouses;
using System.Collections.Generic;
using System.Linq;
using System;
using Beesion.Recruitment.Application;
using Bession.Recruitment.Application;

namespace Beesion.Recruitment.SeniorTest.StockManagement
{
    [BusinessService]
    public class StockService
    {
        private readonly IWarehouse _warehouse;
        public StockService(IWarehouse warehouse)
        {
            if (warehouse == null)
                throw new ArgumentNullException();
            _warehouse = warehouse;
        }

        [BusinessOperation]
        public StockReportDto GetStockReport(string productType, string productId)
        {
            List<int> stocks = new List<int>();
            foreach (var warehouse in _warehouse.GetAll())
            {
                var quantity = warehouse.StockCounts.FirstOrDefault(i => i.ProductType == productType && i.ProductId == productId);
                if (quantity != null)
                    stocks.Add(quantity.Quantity);
                else
                    stocks.Add(0);
            }

            return FillStockReport(stocks);
        }

        private StockReportDto FillStockReport(List<int> stocks)
        {
            var result = new StockReportDto();

            if (stocks.Distinct().Count() > 1)
            {
                result.MinStock = stocks.Min();
                result.MaxStock = stocks.Max();
                result.TotalQuantity = stocks.Sum();
                result.AverageStock = result.TotalQuantity / stocks.Count();
            }
            else
                result.Message = "No tiene stock";

            return result;
        }
    }    
}