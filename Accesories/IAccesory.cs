using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Beesion.Recruitment.SeniorTest.Accesories
{
    public interface IAccesory
    {
        IList<Accesory> GetAll();
        Accesory GetByPartNumber(string partNumber);
    }
}