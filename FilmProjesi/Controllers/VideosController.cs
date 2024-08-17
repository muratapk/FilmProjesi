using Microsoft.AspNetCore.Mvc;

namespace FilmProjesi.Controllers
{
    public class VideosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
