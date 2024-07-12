using BusinessModels.RequestModels;
using BusinessModels.ResponseModels;
using DataAccess.Interfaces;
using Service.Interfaces;
using Service.MappingProfiles;

namespace Service.Implementations
{
    public class ImageService : IImageService
    {
        private readonly IImageDataService _dataService;

        public ImageService(IImageDataService dataService)
        {
            _dataService = dataService;
        }

        /// <summary>
        /// Method to create image
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task CreateImage(ImageRequest request)
        {
            var image = Profiler.ImageRequestToImage(request);
            await _dataService.CreateAsync(image);
        }

        /// <summary>
        /// Method to delete Image
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteImage(int id)
        {
            await _dataService.DeleteAsync(id);
        }

        /// <summary>
        /// Method to Get all Images
        /// </summary>
        /// <returns></returns>
        public async Task<List<ImageResponse>> GetAllImages()
        {
            var dataList = await _dataService.GetAllAsync();
            return Profiler.ImageResponseListFromListImage(dataList.ToList());
        }

        /// <summary>
        /// Method to get Image
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ImageResponse> GetImage(int id)
        {
            var data = await _dataService.GetByIdAsync(id);
            return Profiler.ImageResponseFromImage(data);
        }

        /// <summary>
        /// Method to Update Image
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task UpdateImage(ImageRequest request)
        {
            var image = Profiler.ImageRequestToImage(request);
            await _dataService.UpdateAsync(image);
        }
    }
}
