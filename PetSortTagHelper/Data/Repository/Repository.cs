using Microsoft.EntityFrameworkCore;
using PetSortTagHelper.Data.Interfaces;
using System.Collections.Generic;

namespace PetSortTagHelper.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected PetContext context;

        public Repository(PetContext context)
        {
            this.context = context;
        }

        void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Add(T entity)
        {
            context.Add(entity);
            SaveChanges();
        }

        public void Delete(T entity)
        {
            context.Remove(entity);
            SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return context.Set<T>();
        }

        public T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            context.Set<T>().Update(entity);
            SaveChanges();
        }
    }
}
