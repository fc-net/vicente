using Bession.Recruitment.Application.Core.DTOs;
using System.Collections.Generic;

namespace Beesion.Recruitment.SeniorTest.Warehouses
{
    public interface IWarehouseService
    {
        IList<WarehouseDto> GetAll();
    }
}