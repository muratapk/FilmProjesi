using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class VideosManager : IVideosService
    {
        IVideosDal _videoDal;

        public VideosManager(IVideosDal videoDal)
        {
            _videoDal = videoDal;
        }

        public List<Videos> GetAll()
        {
            return _videoDal.GetAll();
        }

        public void TAdd(Videos entity)
        {
           _videoDal.Add(entity);
        }

        public Videos TGetById(int id)
        {
            return _videoDal.GetById(id);

        }

        public void TRemove(Videos entity)
        {
           _videoDal.Remove(entity);
        }

        public void TUpdate(Videos entity)
        {
            _videoDal.Update(entity);
        }

        public List<Videos> GetList(Expression<Func<Videos, bool>> filter = null)
        {
            if (filter != null)
            {
                // Func<Expression<Func<Videos, bool>>> ifadesini çağırarak filtreyi oluşturuyoruz
                return _videoDal.GetList(filter);
            }
            else
            {
                return _videoDal.GetAll(); // Filtre yoksa tüm veriler getiriliyor
            }
        }

        
    }
}
