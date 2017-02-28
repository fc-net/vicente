using Bession.Recruitment.Domain.Entities.StockEntries;
using System.Collections.Generic;

namespace Bession.Recruitment.Domain.Entities.Warehouse
{
    public class Warehouse
    {
        public string Name { get; set; }
        public List<StockEntry> StockCounts { get; set; }
    }
}
