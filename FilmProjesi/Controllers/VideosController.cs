using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace FilmProjesi.Controllers
{
    public class VideosController : Controller
    {
        
        VideosManager vm = new VideosManager(new EfVideosRepository());
        public IActionResult Index()
        {
            var result = vm.GetAll();
            return View(result);
           
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Videos entity)
        {
            vm.TAdd(entity);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var result=vm.TGetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Videos entity)
        {
            vm.TUpdate(entity);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var result = vm.TGetById(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Delete(Videos entity)
        {
            vm.TRemove(entity);
            return RedirectToAction("Index");
        }
    }
}
