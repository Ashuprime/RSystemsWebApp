using BusinessModels.RequestModels;
using BusinessModels.ResponseModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : Controller
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        // GET: api/image
        [HttpGet]
        public async Task<ActionResult<List<ImageResponse>>> GetImages()
        {
            var images = await _imageService.GetAllImages();
            return Ok(images);
        }

        // GET: api/image/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ImageResponse>> GetImage(int id)
        {
            var image = await _imageService.GetImage(id);
            if (image == null)
            {
                return NotFound();
            }
            return Ok(image);
        }

        // POST: api/image
        [HttpPost]
        public async Task<ActionResult> Createimage([FromBody]ImageRequest image)
        {
            await _imageService.CreateImage(image);
            return CreatedAtAction(nameof(GetImage), new { id = image.Id }, image);
        }

        // PUT: api/image/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Updateimage(int id, [FromBody]ImageRequest image)
        {
            if (id != image.Id)
            {
                return BadRequest();
            }
            var existingimage = await _imageService.GetImage(id);
            if (existingimage == null)
            {
                return NotFound();
            }
            await _imageService.UpdateImage(image);
            return NoContent();
        }

        // DELETE: api/image/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Deleteimage(int id)
        {
            var image = await _imageService.GetImage(id);
            if (image == null)
            {
                return NotFound();
            }
            await _imageService.DeleteImage(id);
            return NoContent();
        }
    }
}
