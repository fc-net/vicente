using Beesion.Recruitment.SeniorTest.Common;

namespace Beesion.Recruitment.SeniorTest.StockManagement
{
    public class StockEntry
    {
        public IProduct Product { get; set; }
        public string ProductType { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}