using Microsoft.EntityFrameworkCore;
using mymusic.models;

namespace mymusic.data
{
    public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Music> Musics { get; set; }
}
}