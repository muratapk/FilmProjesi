using FilmApi.Data;
using FilmApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FilmApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideosController : ControllerBase
    {
        private readonly Context _context;

        public VideosController(Context context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Videos>>>GetVideos()
        {
            return await _context.Videos.ToListAsync();
        }
        [HttpGet("id")]
        public async Task<ActionResult<Videos>>GetVideos(int id)
        {
            return await _context.Videos.FindAsync(id);
        }
        [HttpDelete("id")]
        public async Task<ActionResult<Videos>> DeleteVideos(int id)
        {
            var result =  _context.Videos.Where(x => x.VideoId == id).FirstOrDefault();
            if(result!=null)
            {
                _context.Remove(result);
                await _context.SaveChangesAsync();
            }
            return result;
        }
        [HttpPut("id")]
        public async Task<ActionResult<Videos>> PutVideos(int id, Videos videos)
        {
            var result = _context.Videos.Where(x => x.VideoId == id).FirstOrDefault();
            if (result != null)
            {
                result.Title = videos.Title;
                result.Director = videos.Director;
                result.Actors= videos.Actors;
                result.Picture = videos.Picture;
                result.CategoryId = videos.CategoryId;
                result.Description= videos.Description;
                result.Teaser = videos.Teaser;
                result.Year= videos.Year;
                await _context.SaveChangesAsync();
            }
            return result;
        }
        [HttpPost]
        public async Task<ActionResult<Videos>> PostVideos(Videos video)
        {
            _context.Videos.Add(video);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}
