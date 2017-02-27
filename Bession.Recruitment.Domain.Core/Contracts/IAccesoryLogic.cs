using Bession.Recruitment.Domain.Entities.Accesory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bession.Recruitment.Domain.Core.Contracts
{
    public interface IAccesoryLogic
    {
        Accesory GetByPartNumber(string partNumber);
    }
}
