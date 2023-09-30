using Microsoft.AspNetCore.Mvc;
using mymusic.data;
using mymusic.model;

namespace mymusic.controllers
{
    public class MusicController
    {
        private readonly ApplicationDbContext _context;
        public MusicController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("music")]
        public IActionResult create(Music music)
        {
            _context?.Add(music);
            _context?.SaveChanges();
            return (IActionResult)music;
        }
    }
}