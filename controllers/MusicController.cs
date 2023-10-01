using Microsoft.AspNetCore.Mvc;
using mymusic.data;
using mymusic.models;

namespace mymusic.controllers
{
    [ApiController]
    [Route("/musics/")]
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

        [HttpGet("{title}")]
        public IActionResult Search(string title)
        {
            try
            {
                var music = _context.Musics
                                    .Where(m => m.Title == title)
                                    .FirstOrDefault();

                if (music == null){
                    return NotFound();
                }
                return Ok(music);
            }
            catch (System.Exception)
            {
                
                return BadRequest();
            }
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

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Music music)
        {
            try
            {
                var musicBanco = _context.Musics.Find(id);
                if(musicBanco == null){
                    return NotFound();
                }
                musicBanco.Title = music.Title;
                musicBanco.Artist = music.Artist;
                musicBanco.Composer = music.Composer;
                musicBanco.Album = music.Album;
                musicBanco.MusicalGenre = music.MusicalGenre;
                musicBanco.Duration = music.Duration;

                _context.Musics.Update(musicBanco);
                _context.SaveChanges();
                return Ok(musicBanco);
            }
            catch (System.Exception)
            {
                return BadRequest();
            }
        }
    }
}