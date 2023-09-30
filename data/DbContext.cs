using Microsoft.EntityFrameworkCore;
using mymusic.model;

namespace mymusic.data
{
    public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    // Defina DbSet para suas entidades aqui
    public DbSet<Music> Musics { get; set; }
}
}