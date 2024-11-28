using Bookstore.Core.Models;
using Bookstore.Core.Services;
using Bookstore.Data;

namespace Bookstore.Services
{
    public class EntityService<T> : DbService, IEntityService<T> where T : Entity
    {
        public EntityService(BookStoreDbContext context) : base(context)
        {
        }

        public T? GetById(int id)
        {
            return GetById<T>(id);
        }

        public ServiceResult Create(T entity)
        {
            return Create<T>(entity);
        }

        public ServiceResult Delete(T entity)
        {
            return Delete<T>(entity);
        }

        public ServiceResult Update(T entity)
        {
            return Update<T>(entity);
        }

        public IEnumerable<T> List()
        {
            return List<T>();
        }
    }
}
