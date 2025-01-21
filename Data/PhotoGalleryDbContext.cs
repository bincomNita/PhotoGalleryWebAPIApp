
using Microsoft.EntityFrameworkCore;
using PhotoGalleryWebAPIApp.Model;
namespace PhotoGalleryWebAPIApp.Data
{
    public class PhotoGalleryDbContext(DbContextOptions<PhotoGalleryDbContext> options) : DbContext(options)
    {
        public DbSet<Galleryitem> Galleryitems { get; set; }
    }


}
