using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Interfaces.Repository;

namespace Infrastructure.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        Context _context;
        public Repository(Context context)
        {
            _context = context;
        }
        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }
        public T GetByEmail(string email)
        {
            return _context.Set<T>().FirstOrDefault();
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().FirstOrDefault(expression);
        }
        //public T Get(string word)
        //{
        //    return _context.Set<T>().
        //}
        public IEnumerable<T> GetAll()
        {
           return _context.Set<T>().ToList();
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }
        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);  
           return entity;
        }

        public  T Delete(int id)
        {
           var entity =  _context.Set<T>().Find(id);
            _context.Set<T>().Remove(entity);
            return entity;
        }

        public IEnumerable<T> get(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression).ToList(); 
        }
    }
}
