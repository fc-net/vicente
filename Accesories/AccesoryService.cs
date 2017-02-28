using Beesion.Recruitment.SeniorTest.Services;
using Bession.Recruitment.Application.Core.DTOs;
using Bession.Recruitment.Domain.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bession.Recruitment.Application.Accesories
{
    [BusinessService]
    public class AccesoryService : IAccesoryService
    {
        private readonly IAccesoryRepository _accesoryRespository;
        public AccesoryService(IAccesoryRepository accesoryRespository)
        {
            if (accesoryRespository == null)
                throw new ArgumentNullException();
            _accesoryRespository = accesoryRespository;
        }

        [BusinessOperation]
        public IList<AccesoryDto> GetAll()
        {
            var accesory = _accesoryRespository.GetAll().ToList();

            return MapperAccesory.GetAccesoryDto(accesory);
        }
    }
}
