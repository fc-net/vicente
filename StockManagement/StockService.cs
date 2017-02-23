using Beesion.Recruitment.SeniorTest.Services;
using Beesion.Recruitment.SeniorTest.Warehouses;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Beesion.Recruitment.SeniorTest.StockManagement
{
    [BusinessService]
    public class StockService
    {
        public readonly IWarehouse _warehouse;
        public StockService(IWarehouse warehouse)
        {
            if (warehouse == null)
                throw new ArgumentNullException();
            _warehouse = warehouse;
        }

        [BusinessOperation]
        public StockReport GetStockReport(string productType, string productId)
        {
            int locations = 0;
            List<int> stocks = new List<int>();
            foreach (var warehouse in _warehouse.GetAll())
            {
                locations++;
                foreach (var stockCount in warehouse.StockCounts)
                {
                    if (string.Compare(productType, stockCount.ProductType) == 0 && string.Compare(productId, stockCount.ProductId) == 0)
                    {
                        stocks.Add(stockCount.Quantity);
                    }
                }
            }

            return FillStockReport(stocks, locations);
        }

        private StockReport FillStockReport(List<int> stocks, int locations)
        {
            var result = new StockReport();

            if (stocks.Count > 0)
            {
                result.MinStock = stocks.Count > 1 ? stocks.Min() : 0;
                result.MaxStock = stocks.Max();
                result.TotalQuantity = stocks.Sum();
                result.AverageStock = result.TotalQuantity / (decimal)locations;
            }
            else
                result.Message = "No tiene stock";

            return result;
        }
    }


    public class StockReport
    {
        public int TotalQuantity { get; set; }
        public int MinStock { get; set; }
        public int MaxStock { get; set; }
        public decimal AverageStock { get; set; }
        public string Message { get; set; }
    }
}