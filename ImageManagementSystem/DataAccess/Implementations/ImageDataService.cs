using DataAccess.DataObjectValidator;
using DataAccess.Interfaces;
using DataObjects;
using FluentValidation;
using System.Text.Json;

namespace DataAccess.Implementations
{
    public class ImageDataService : IImageDataService
    {
        private readonly string _filePath;
        private List<Image> _Images;
        private readonly ImageValidator _validator;

        public ImageDataService(string filePath)
        {
            _filePath = filePath;
            _validator = new ImageValidator();
            _Images = new List<Image>();
            LoadDataAsync().Wait(); // Synchronously load data for simplicity
        }


        public async Task CreateAsync(Image entity)
        {
            entity.Id = GetNextId();
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            _Images.Add(entity);
            await SaveDataAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var image = _Images.Find(u => u.Id == id);
            if (image != null)
            {
                _Images.Remove(image);
                await SaveDataAsync();
            }
        }

        public async Task<IEnumerable<Image>> GetAllAsync()
        {
            return await Task.FromResult(_Images);
        }

        public async Task<Image> GetByIdAsync(int id)
        {
            return await Task.FromResult(_Images.Find(u => u.Id == id) ?? new Image());
        }

        public async Task UpdateAsync(Image entity)
        {
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            var image = _Images.Find(u => u.Id == entity.Id);
            if (image != null)
            {
                image.User = entity.User;
                image.Description = entity.Description;
                image.URL = entity.URL;
                await SaveDataAsync();
            }
        }

        private async Task LoadDataAsync()
        {
            if (File.Exists(_filePath))
            {
                var json = await File.ReadAllTextAsync(_filePath);
                _Images = JsonSerializer.Deserialize<List<Image>>(json) ?? new List<Image>();
            }
        }

        private async Task SaveDataAsync()
        {
            var json = JsonSerializer.Serialize(_Images, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_filePath, json);
        }

        private int GetNextId()
        {
            if(_Images.Count == 0)
                return 1;


            int id = _Images.Max(i => i.Id);
            return ++id;
        }
    }
}
