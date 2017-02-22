using Beesion.Recruitment.SeniorTest.Services;
using Beesion.Recruitment.SeniorTest.Warehouses;

namespace Beesion.Recruitment.SeniorTest.StockManagement
{
    [BusinessService]
    public class StockService
    {
        [BusinessOperation]
        public StockReport GetStockReport(string productType, string productId)
        {
            var result = new StockReport();
            int locations = 0;
            foreach (var warehouse in WarehouseRepository.GetAll())
            {
                foreach (var stockCount in warehouse.StockCounts)
                {
                    if(string.Compare(productType,stockCount.ProductType)==0 && string.Compare(productId, stockCount.ProductId)==0)
                    {
                        locations++;
                        if (result.MinStock > stockCount.Quantity)
                            result.MinStock = stockCount.Quantity;
                        if (result.MaxStock < stockCount.Quantity)
                            result.MaxStock = stockCount.Quantity;
                        result.TotalQuantity++;
                    }
                }
            }
            result.AverageStock = result.TotalQuantity/(decimal)locations;
            return result;
        }
    }


    public class StockReport
    {
        public int TotalQuantity { get; set; }
        public int MinStock { get; set; }
        public int MaxStock { get; set; }
        public decimal AverageStock { get; set; }
    }
}