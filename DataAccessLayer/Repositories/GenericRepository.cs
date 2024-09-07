using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        //private readonly Context _context;

        //public GenericRepository(Context context)
        //{
        //    _context = context;
        //}
        protected Context _context = new Context();

        public void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();

        }

        public List<T> GetAll()
        {
           return _context.Set<T>().ToList();   
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Where(filter).ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetList(Expression<Func<T, bool>> filter)
        {
            if (filter != null)
            {
                return _context.Set<T>().Where(filter).ToList(); // Filtre uygulanıyor
            }
            else
            {
                return _context.Set<T>().ToList(); // Filtre yoksa tüm kayıtlar getiriliyor
            }

        }

        public void Remove(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges(); 
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
