using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_read_infraestrutura.Persistence
{
    public interface IRepository<T>
    {
        void Insert (T entity);
        void Update (T entity);
        void Delete (T entity);
        void Delete(object id);

        IQueryable<T> Get(Expression<Func<T, bool>> predicate = null);

        T Find(object id);



    }
}
