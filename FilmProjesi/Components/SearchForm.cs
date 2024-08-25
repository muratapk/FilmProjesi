using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace FilmProjesi.Components
{
    public class SearchForm: ViewComponent
    {
        VideosManager vm = new VideosManager(new EfVideosRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
