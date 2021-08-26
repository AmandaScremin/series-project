using System;
using System.Collections.Generic;
using System.Text;


namespace RegisterApp.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();

        T ReturnById(int id);
        void Insert(T entity);
        void Exclude(int id);
        void Update(int id, T entity);
        int NextId();
    }
}
