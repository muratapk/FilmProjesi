using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }

        public List<Category> GetList(Expression<Func<Category, bool>> filter = null)
        {
            if (filter != null)
            {
                // Func<Expression<Func<Videos, bool>>> ifadesini çağırarak filtreyi oluşturuyoruz
                return _categoryDal.GetList(filter);
            }
            else
            {
                return _categoryDal.GetAll(); // Filtre yoksa tüm veriler getiriliyor
            }
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
