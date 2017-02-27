using Bession.Recruitment.Application.Core.DTOs;
using System.Collections.Generic;

namespace Bession.Recruitment.Application.Accesories
{
    public interface IAccesoryService
    {
        IList<AccesoryDto> GetAll();
    }
}
