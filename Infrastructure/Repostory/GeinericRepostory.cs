using Core.Interfases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repostory
{
    public class GeinericRepostory<T> : IGenericRepostory<T> where T : class
    {
        private readonly DataContext _context;
        private DbSet<T> table=null;
        public GeinericRepostory (DataContext Context)
        {
            _context = Context;
            table = _context.Set<T>();
        }
        public void Delete(object Id)
        {
            T existing = GetByID(Id);
             table.Remove(existing);
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();
        }

        public T GetByID(object Id)
        {
            return table.Find(Id);
        }

        public void Insert(T entity)
        {
            table.Add(entity);
        }

        public void Update(T entity)
        {
            table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
