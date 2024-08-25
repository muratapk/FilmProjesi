using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FilmProjesi.Components
{
    public class TrendFilms: ViewComponent
    {
        VideosManager vm = new VideosManager(new EfVideosRepository());

        public IViewComponentResult Invoke()
        {
            var result = vm.GetAll();
            return View(result);
        }
    }
}
