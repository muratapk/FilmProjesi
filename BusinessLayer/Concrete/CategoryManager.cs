﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

       

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public void TAdd(Category entity)
        {
           _categoryDal.Add(entity);
        }

        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);    
        }

        public void TRemove(Category entity)
        {
            _categoryDal.Remove(entity);
        }

        public void TUpdate(Category entity)
        {
            _categoryDal.Update(entity);
        }
    }
}
