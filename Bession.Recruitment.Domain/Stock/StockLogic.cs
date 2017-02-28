using Bession.Recruitment.Domain.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bession.Recruitment.Domain.Entities.StockEntries;
using Bession.Recruitment.Domain.Entities.Warehouse;
using Bession.Recruitment.Application.Core.DTOs;

namespace Bession.Recruitment.Domain.Stock
{
    public class StockLogic : IStockLogic
    {
        public StockReportDto GetStockReport(IQueryable<Warehouse> warehouses, string productType, string productId)
        {
            List<int> stocks = new List<int>();
            foreach (var warehouse in warehouses.ToList())
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
