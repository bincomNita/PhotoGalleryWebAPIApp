using Microsoft.VisualBasic;
using PhotoGalleryWebAPIApp.Data;
using PhotoGalleryWebAPIApp.Interface;
using PhotoGalleryWebAPIApp.Model;

namespace PhotoGalleryWebAPIApp.Repositiories
{
    public class PhotoGalleryRepository(PhotoGalleryDbContext context) : IPhotoGalleryRepository
    {
        private readonly PhotoGalleryDbContext _context = context;


        public async Task<Galleryitem> GetGalleryItem(int id)
        {
            return await _context.Galleryitems.FindAsync(id);

        }

        public IEnumerable<Galleryitem> GetGalleryItems()
        {
            return _context.Galleryitems.OrderBy(m => m.Id).ToList();
        }
        public bool GalleryExist(int id)
        {
            return _context.Galleryitems.Any(m => m.Id == id);
        }
        public async Task<bool> CreateGalleryItems(Galleryitem galleryitem)
        {
            _context.Galleryitems.Add(galleryitem);
            return await Save();
        }
        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }
    }
}



