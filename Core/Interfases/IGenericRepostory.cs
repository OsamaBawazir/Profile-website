using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfases
{
    public  interface IGenericRepostory<T> where T:class
    {
        IEnumerable<T> GetAll();
        T GetByID(object Id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(object Id);

    }
}
