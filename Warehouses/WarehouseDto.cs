using Beesion.Recruitment.SeniorTest.Common;

namespace Beesion.Recruitment.SeniorTest.Warehouses
{
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