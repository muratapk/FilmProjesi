using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
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
        [HttpGet]
        public IActionResult Create() 
        {
           return View();
        }
        [HttpPost]  
        public IActionResult Create(Category entity)
        {
            categoryManager.TAdd(entity);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result=categoryManager.TGetById(id);
            return View(result);
        }
        [HttpPost]  
        public IActionResult Edit(Category entity)
        {
            categoryManager.TUpdate(entity);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
          var result =categoryManager.TGetById(id);
            return View(result);
        
        }
        [HttpPost]
        public IActionResult Delete(Category entity)
        {
            categoryManager.TRemove(entity);
            return RedirectToAction("Index");
        }
    }
}
