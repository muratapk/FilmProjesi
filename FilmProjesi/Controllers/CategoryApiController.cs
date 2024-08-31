using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

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
        [HttpGet]
        public IActionResult Create()
        { 
           return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            try
            {
               string data=JsonConvert.SerializeObject(category);
               StringContent content=new StringContent(data,Encoding.UTF8,"Application/Json");
                HttpResponseMessage response = _client.PostAsync(_client.BaseAddress + "/Category/",content).Result;
                if(response.IsSuccessStatusCode) {
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                TempData["Error"] = ex;
                return View();
            }
            return View(category);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                Category category = new Category();
                HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Category/" + id).Result;
                if(response.IsSuccessStatusCode)
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    category=JsonConvert.DeserializeObject<Category>(data);
                    View(category);
                }
            }
            catch(Exception ex)
            {
                TempData["Error"] = ex;
                return View();
            }
            return View();
        }
        [HttpPost]
        public IActionResult Delete(int id, Category category)
        {
            try
            {
                HttpResponseMessage response = _client.DeleteAsync(_client.BaseAddress + "/Category/" + id).Result;
                if(response.IsSuccessStatusCode)
                {
                    TempData["Success"] = "İşlem Başarılı";
                    return RedirectToAction("index");
                }
            }
            catch(Exception ex)
            {
                TempData["Error"] = "Hata Oluştu";
                return View();
            }
            return View();
        }
    }
}
