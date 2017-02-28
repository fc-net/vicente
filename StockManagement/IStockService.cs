using Bession.Recruitment.Application.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beesion.Recruitment.SeniorTest.StockManagement
{
    public interface IStockService
    {
        StockReportDto GetStockReport(string productType, string productId);
    }
}