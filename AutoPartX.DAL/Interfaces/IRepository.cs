using System.Collections.Generic;

namespace AutoPartX.DAL.Interfaces
{
    public interface IRepository<T, ID>
    {
        void Create(T obj);
        List<T> GetAll();
        T GetById(ID id);
        bool Update(T obj);
        bool Delete(ID id);
    }
}