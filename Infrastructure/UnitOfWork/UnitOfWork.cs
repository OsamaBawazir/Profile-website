using Core.Interfases;
using Infrastructure.Repostory;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T:class
    {
        private readonly DataContext _context;
        private IGenericRepostory<T> _entity;
        public UnitOfWork(DataContext context )
        {
            _context = context;
        }
        

        public IGenericRepostory<T> Entity 
        {
            get { return _entity ?? (_entity = new GeinericRepostory<T>(_context)); }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
