using Bession.Recruitment.Domain.Core.Contracts;
using Bession.Recruitment.Domain.Core.Repositories;
using Bession.Recruitment.Domain.Entities.Accesory;
using System;
using System.Linq;

namespace Bession.Recruitment.Domain.Accesories
{
    public class AccesoryLogic : IAccesoryLogic
    {
        private readonly IAccesoryRepository _accesoryRepository;
        public AccesoryLogic(IAccesoryRepository accesoryRepository)
        {
            if (accesoryRepository == null)
                throw new ArgumentNullException();
            _accesoryRepository = accesoryRepository;
        }
        public Accesory GetByPartNumber(string partNumber)
        {
            return _accesoryRepository.GetAll().FirstOrDefault(s => string.Compare(partNumber, s.PartNumber) == 0);
        }
    }
}
