using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_read_infraestrutura.Persistence.People
{
    public class PersonRepository : IPersonRepository
    {

        private static List<Person> listPersonMemory = new List<Person>();
        public void Delete(Person entity)
        {
            listPersonMemory.Remove(entity);
        }

        public void Delete(object id)
        {
            listPersonMemory.Remove(this.Find(id));
        }

        public Person Find(object id)
        {
            return listPersonMemory.AsQueryable().FirstOrDefault(p => p.id.Equals(id));
        }

        public IQueryable<Person> Get(Expression<Func<Person, bool>> predicate)
        {
            return predicate != null ?
                listPersonMemory.AsQueryable().Where(predicate)
                : listPersonMemory.AsQueryable();
        }

        public void Insert(Person entity)
        {
            if(entity.id == 1)
            {
                entity = new Person
                (listPersonMemory.Count + 1, entity.Class, entity.Name, entity.Age);
            }
        }

        public void Update(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
