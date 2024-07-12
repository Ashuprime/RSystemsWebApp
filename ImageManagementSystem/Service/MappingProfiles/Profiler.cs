
using BusinessModels.RequestModels;
using BusinessModels.ResponseModels;
using DataObjects;

namespace Service.MappingProfiles
{
    public static class Profiler
    {
        public static Image ImageRequestToImage(ImageRequest request)
        {
            return new Image(request.Id, request.User, request.Description, request.URL);
        }

        public static ImageResponse ImageResponseFromImage(Image image)
        {
            return new ImageResponse()
            {
                Id = image.Id,
                User = image.User,
                DateCreated = image.DateCreated,
                Description = image.Description,
                URL = image.URL
            };
        }

        public static List<ImageResponse> ImageResponseListFromListImage(List<Image> imageList)
        {
            List<ImageResponse> imageResponseList = new List<ImageResponse>();
            foreach (Image image in imageList)
            {
                imageResponseList.Add(ImageResponseFromImage(image));
            }

            return imageResponseList;
        }
    }
}
