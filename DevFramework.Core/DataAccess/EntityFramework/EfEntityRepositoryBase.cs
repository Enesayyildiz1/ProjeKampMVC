using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<T, Context> : IEntityRepository<T>
        where T : class, IEntity, new()
        where Context : DbContext, new()
    {
        public T Add(T entity)
        {
            using (var context = new Context())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
                return entity;

            }
        }

        public void Delete(T entity)
        {
            using (var context = new Context())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();

            }
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            using (var context = new Context())
            {
                return context.Set<T>().SingleOrDefault(filter);
            }
        }

        public List<T> GetList(Expression<Func<T, bool>> filter = null)
        {
            using (var context = new Context())
            {
                if (filter == null)
                {
                    return context.Set<T>().ToList();
                }
                else
                {
                    return context.Set<T>().Where(filter).ToList();
                }
            }
        }

        public T Update(T entity)
        {
            using (var context = new Context())
            {
                var updatedentity = context.Entry(entity);
                updatedentity.State = EntityState.Modified;
                context.SaveChanges();
                return entity;
            }
        }
    }
}
