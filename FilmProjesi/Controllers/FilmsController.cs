using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FilmProjesi.Controllers
{
    public class FilmsController : Controller
    {
        VideosManager vm = new VideosManager(new EfVideosRepository());
        CategoryManager cm = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Details(int id)
        {
            var result = vm.TGetById(id);
            return View(result);
        }
        public IActionResult CategoryList(int id)
        {
            var result=vm.TGetById(id);
            return View(result);

        }
    }
}
