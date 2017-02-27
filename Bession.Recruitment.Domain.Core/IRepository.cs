using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bession.Recruitment.Domain.Core
{
    public interface IRepository<TModel> where TModel : class
    {
        IQueryable<TModel> GetAll();
        TModel GetById(long id);
        TModel GetById(string id);
    }
}
