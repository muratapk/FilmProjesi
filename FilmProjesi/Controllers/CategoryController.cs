using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FilmProjesi.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm=new CategoryManager();
        public IActionResult Index()
        {
            return View();
        }
    }
}
