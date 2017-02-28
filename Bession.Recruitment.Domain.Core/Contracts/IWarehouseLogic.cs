using Bession.Recruitment.Domain.Core.Repositories;
using Bession.Recruitment.Domain.Entities.Accesory;
using Bession.Recruitment.Domain.Entities.Device;
using Bession.Recruitment.Domain.Entities.Warehouse;
using System.Collections.Generic;
using System.Linq;

namespace Bession.Recruitment.Domain.Core.Contracts
{
    public interface IWarehouseLogic
    {
        IList<Warehouse> GetAll(IQueryable<Warehouse> warehouse);
    }
}
