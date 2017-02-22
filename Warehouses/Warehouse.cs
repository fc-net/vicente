using System.Collections.Generic;
using Beesion.Recruitment.SeniorTest.StockManagement;

namespace Beesion.Recruitment.SeniorTest.Warehouses
{
    public class Warehouse
    {
        public string Name { get; set; }
        public List<StockEntry> StockCounts { get; set; }
    }
}