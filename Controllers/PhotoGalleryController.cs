using Microsoft.AspNetCore.Mvc;
using PhotoGalleryWebAPIApp.Interface;
using PhotoGalleryWebAPIApp.Model;

namespace PhotoGalleryWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoGalleryController(IPhotoGalleryRepository photoGalleryRepository) : ControllerBase
    {
        private readonly IPhotoGalleryRepository? photoGalleryRepository;

        [HttpGet]       
        public IActionResult GetGalleryItems()
        {
            var movies = photoGalleryRepository.GetGalleryItems();
            return Ok(movies);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGalleryItem(int id)
        {

            if (!photoGalleryRepository.GalleryExist(id))
                return NotFound();
            var movie = await photoGalleryRepository.GetGalleryItem(id);
            return Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGalleryItems(Galleryitem galleryitem)
        {
            if (galleryitem == null) return BadRequest(ModelState);

            var createdMovie = await photoGalleryRepository.CreateGalleryItems(galleryitem);
            if (!createdMovie) return BadRequest("Error while creating gallery item");
            return Ok("New gallery item added");
        }
    }
}
