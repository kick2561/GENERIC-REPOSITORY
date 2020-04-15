using GenericRepository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GenericRepository.Generic_Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private EmployeeEntity _context = null;
        private DbSet<T> table = null;

        //public Repository()
        //{
        //    this._context = new EmployeeEntity();
        //    table = _context.Set<T>();
        //}

        public Repository(EmployeeEntity _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }

        public void Delete(object id)
        {
            T existing = table.Find(id);
            table.Remove(existing);
        }

        public IEnumerable<T> GetAll()
        {
            return table.ToList();

        }

        public T GetById(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
    }
}