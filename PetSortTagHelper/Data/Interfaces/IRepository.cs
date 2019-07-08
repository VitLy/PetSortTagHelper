using System.Collections.Generic;

namespace PetSortTagHelper.Data.Interfaces
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Delete(T entity);
        T GetById(int id);
        void Update(T entity);
    }
}
