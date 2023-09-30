using Microsoft.AspNetCore.Mvc;
using mymusic.data;
using mymusic.model;

namespace mymusic.controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class MusicController : ControllerBase
    {
        public readonly ApplicationDbContext _context;
        public MusicController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Music music)
        {
            try
            {
                _context.Add(music);
                _context.SaveChanges();
                return Ok(music);
            }
            catch (Exception)
            {
                return BadRequest();
                
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            dynamic allMusics = _context.Musics.ToList();
            return Ok(allMusics);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var music = _context.Musics.Find(id);

                if(music == null){
                    return NotFound();
                }
                _context.Musics.Remove(music);
                _context.SaveChanges();
                return Ok("Music deleted");      
            }
            catch (Exception)
            {
                return BadRequest();
            }     
        }
    }
}