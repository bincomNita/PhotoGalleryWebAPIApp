using PhotoGalleryWebAPIApp.Model;

namespace PhotoGalleryWebAPIApp.Interface
{
    public interface IPhotoGalleryRepository
    {
        IEnumerable<Galleryitem> GetGalleryItems();
        Task<Galleryitem> GetGalleryItem(int id);
        Task<bool> CreateGalleryItems(Galleryitem galleryitem);
        Task<bool> Save();
        bool GalleryExist(int id);
    }
}
