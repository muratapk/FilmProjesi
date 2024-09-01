using FilmApi.Data;
using FilmApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FilmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly Context _context;

        public CategoryController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        
        public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        {
            return await _context.Categories.ToListAsync();
        }
        [HttpGet("Get/{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            return await _context.Categories.FindAsync(id);
        }
        [HttpDelete("id")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var result = await _context.Categories.Where(x => x.CategoryId == id).FirstOrDefaultAsync();
            if(result!=null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
            }
            return result;
            
        }
        [HttpPut("id")]
        public  async Task<ActionResult<Category>> PutCategory(int id,Category category)
        {

            if (id != category.CategoryId)
            {
                return BadRequest("Category ID mismatch");
            }


            var bul = await _context.Categories
                                          .Where(x => x.CategoryId == id)
                                          .FirstOrDefaultAsync();
            if (bul!=null)
            {
                bul.CategoryName = category.CategoryName;
              
                await _context.SaveChangesAsync();
                
            }
            return Ok();

        }
        [HttpPost]
        public async Task<ActionResult<Category>>PostCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
    
}
