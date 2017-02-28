using Bession.Recruitment.Domain.Core.Repositories;
using Bession.Recruitment.Domain.Entities.StockEntries;
using Bession.Recruitment.Domain.Entities.Warehouse;
using System.Collections.Generic;
using System.Linq;

namespace Bession.Recruitment.Data.Repositories
{
    public class WarehouseRepository : RepositoryBase<Warehouse>, IWarehouseRepository
    {
        private readonly IList<Warehouse> items = new List<Warehouse>
        {
            new Warehouse{Name="Denver",StockCounts = new List<StockEntry>
                {
                    new StockEntry{ProductType = "DEV",ProductId = "CCHA-HTCINC2",Quantity = 20},
                    new StockEntry{ProductType = "DEV",ProductId = "RCHA-HTCINC2",Quantity = 40},
                    new StockEntry{ProductType = "DEV",ProductId = "CASE-IPHO3SKBCKS",Quantity = 10},
                    new StockEntry{ProductType = "DEV",ProductId = "896352523425",Quantity = 220},
                    new StockEntry{ProductType = "DEV",ProductId = "79032468236482",Quantity = 60},
                    new StockEntry{ProductType = "DEV",ProductId = "75698638475673",Quantity = 8}
                }
            },
            new Warehouse{Name="Boston",StockCounts = new List<StockEntry>
                {
                    new StockEntry{ProductType = "DEV",ProductId = "CCHA-HTCINC2",Quantity = 70},
                    new StockEntry{ProductType = "DEV",ProductId = "RCHA-HTCINC2",Quantity = 46},
                    new StockEntry{ProductType = "DEV",ProductId = "CASE-IPHO3SKBCKS",Quantity = 120},
                    new StockEntry{ProductType = "ACC",ProductId = "896352523425",Quantity = 80},
                    new StockEntry{ProductType = "ACC",ProductId = "79032468236482",Quantity = 10},
                    new StockEntry{ProductType = "ACC",ProductId = "75698638475673",Quantity = 88}
                }
            },
            new Warehouse{Name="Miami",StockCounts = new List<StockEntry>
                {
                    new StockEntry{ProductType = "DEV",ProductId = "CCHA-HTCINC2",Quantity = 51},
                    new StockEntry{ProductType = "DEV",ProductId = "RCHA-HTCINC2",Quantity = 42},
                    new StockEntry{ProductType = "DEV",ProductId = "CASE-IPHO3SKBCKS",Quantity = 145},
                    new StockEntry{ProductType = "DEV",ProductId = "CCHA-UNUSB5C",Quantity = 98},
                    new StockEntry{ProductType = "DEV",ProductId = "CASE-SAMA237CON",Quantity = 16},
                    new StockEntry{ProductType = "DEV",ProductId = "75698638475673",Quantity = 218}
                }
            },
        };

        override public IQueryable<Warehouse> GetAll()
        {
            return items.AsQueryable();
        }
    }
}
