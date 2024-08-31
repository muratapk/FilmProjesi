using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FilmProjesi.Controllers
{
    public class CategoryApiController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7121/api");
        private readonly HttpClient _client;

        public CategoryApiController()
        {
          
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Category> categories = new List<Category>();
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Category/").Result;
            if(response.IsSuccessStatusCode)
            {
                string data=response.Content.ReadAsStringAsync().Result;
                categories=JsonConvert.DeserializeObject<List<Category>>(data);
            }
          
            return View(categories);
        }
    }
}
