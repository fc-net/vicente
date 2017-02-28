using Bession.Recruitment.Application.Core.DTOs;
using Bession.Recruitment.Domain.Entities.Warehouse;
using System.Linq;

namespace Bession.Recruitment.Domain.Core.Contracts
{
    public interface IStockLogic
    {
        StockReportDto GetStockReport(IQueryable<Warehouse> warehouse, string productType, string productId);
    }
}
