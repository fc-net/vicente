using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bession.Recruitment.Domain.Core.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public virtual IQueryable<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetById(string id)
        {
            throw new NotImplementedException();
        }

        public virtual TEntity GetById(long id)
        {
            throw new NotImplementedException();
        }
    }
}
