using System.Collections.Generic;
using Beesion.Recruitment.SeniorTest.Services;
using System;

namespace Beesion.Recruitment.SeniorTest.Accesories
{
    [BusinessService]
    public class AccesoriesService
    {
        public readonly IAccesory _accesory;
        public AccesoriesService(IAccesory accesory)
        {
            if (accesory == null)
                throw new ArgumentNullException();
            _accesory = accesory;
        }

        [BusinessOperation]
        public IList<AccesoryDto> GetAll()
        {
            var accesories = _accesory.GetAll();
            return GetAccesoryDto(accesories);
        }

        private IList<AccesoryDto> GetAccesoryDto(IList<Accesory> accesories)
        {
            var result = new List<AccesoryDto>();

            foreach (var acc in accesories)
            {
                result.Add(new AccesoryDto
                {
                    Brand = acc.Brand,
                    Description = acc.Description,
                    PartNumber = acc.PartNumber
                });
            }

            return result;
        }
    }
}