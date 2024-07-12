using BusinessModels.RequestModels;
using BusinessModels.ResponseModels;

namespace Service.Interfaces
{
    public interface IImageService
    {
        public Task<List<ImageResponse>> GetAllImages();
        public Task<ImageResponse> GetImage(int id);
        public Task CreateImage(ImageRequest request);
        public Task DeleteImage(int id);
        public Task UpdateImage(ImageRequest request);
    }
}
