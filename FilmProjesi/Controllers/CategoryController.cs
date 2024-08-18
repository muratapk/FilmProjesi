using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FilmProjesi.Controllers
{
    public class CategoryController : Controller
    {
     CategoryManager categoryManager = new CategoryManager(new EfCategoryRepository());
        public IActionResult Index()
        {
           var result= categoryManager.GetAll();
            return View(result);
        }
    }
}
