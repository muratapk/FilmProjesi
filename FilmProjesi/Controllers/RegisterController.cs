using EntityLayer.Concrete;
using FilmProjesi.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FilmProjesi.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(AppUserRegisterDto appUserRegisterDto)
        {
            Random random = new Random();
            int code = 0;
            code = random.Next(10000, 10000001);

            AppUser appuser=new AppUser()
            {
                FirstName=appUserRegisterDto.FirstName,
                LastName=appUserRegisterDto.LastName,
                ConfirmCode=appUserRegisterDto.ConfirmCode,
                
            };

            return View();
        }
    }
}
