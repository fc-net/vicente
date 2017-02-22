using System.Collections.Generic;
using Beesion.Recruitment.SeniorTest.Services;

namespace Beesion.Recruitment.SeniorTest.Accesories
{
    [BusinessService]
    public class AccesoriesService
    {
        [BusinessOperation]
        public IList<Accesory> GetAll()
        {
            return AccesoriesRepository.GetAll();
        }
    }
}