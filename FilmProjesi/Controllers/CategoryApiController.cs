using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace FilmProjesi.Controllers
{
    public class CategoryApiController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7121/api");
        //kullanacağımz api yolu alıyorum baseAdress buradan çekiyorum
        private readonly HttpClient _client;
        /// <summary>
        /// istemci oluşturuyorum.
        /// </summary>
        public CategoryApiController()
        {
          
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }
        [HttpGet]
        public IActionResult Index()
        {
            List<Category> categories = new List<Category>();
            //bir liste oluştur categori listesi olacak
            HttpResponseMessage response = _client.GetAsync(_client.BaseAddress + "/Category/").Result;
            //getAsnc metodu ile veri çek _clientBaseAddress http://localhost:7121/api
            if(response.IsSuccessStatusCode)
            {
                //response.IsSuccessStatusCode 200
                string data=response.Content.ReadAsStringAsync().Result;
                //gelen veri ReadAstring olarak oku ve data at
                categories=JsonConvert.DeserializeObject<List<Category>>(data);
                // veri formatına çevir json verisini veri çevirdik
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
                //gelen veriyi al json formatın çevir
               StringContent content=new StringContent(data,Encoding.UTF8,"Application/Json");

                //data içerisine json verisinin utf-8 biçiinde olacağın yazıyoruz.
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
        public async Task<IActionResult> Delete(int id)
        {

            try
            {
                Category category = new Category();
                HttpResponseMessage response = await _client.GetAsync(_client.BaseAddress + "/Category/Get" + id);

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    category = JsonConvert.DeserializeObject<Category>(data);
                    return View(category);
                }
                else
                {
                    // Hata durumunu işlemek için buraya ekleme yapın
                    return View("Error");
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
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            try
            {
                Category category = new Category();
                HttpResponseMessage response = await _client.GetAsync($"{_client.BaseAddress}/Category/Get/{id}");
                if (response.IsSuccessStatusCode)
                {
                    string data =await response.Content.ReadAsStringAsync();
                    category = JsonConvert.DeserializeObject<Category>(data);
                    return View(category);
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
        public IActionResult Edit(int id,Category category)
        {
            try
            {
                string data=JsonConvert.SerializeObject(category);
                StringContent content=new StringContent(data,Encoding.UTF8,"Application/Json");
                HttpResponseMessage response = _client.PutAsync(_client.BaseAddress + "/Category/", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            catch(Exception ex)
            {
                TempData["Error"] = ex;
                return View();
            }
            return View();
        }
    }
}
