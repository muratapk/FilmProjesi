﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T>where T:class
    {
        void Add(T entity); 
        void Update(T entity);
        void Remove(T entity);
        T GetById(int id);
        List<T>GetAll();
        List<T>GetList(Expression<Func<T, bool>> filter);
        //bizim isteğimize göre verileri filterlemek için kullanıyor

    }
}
