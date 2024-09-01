using Microsoft.AspNetCore.Mvc;

namespace FilmProjesi.Controllers
{
    public class VideoApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
