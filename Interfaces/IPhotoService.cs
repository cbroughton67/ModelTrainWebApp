using CloudinaryDotNet.Actions;

namespace ModelTrainWebApp.Interfaces
{
    public interface IPhotoService
    {

        //*************************************************************************************************
        // Required Feature: Connect to an external/3rd party API (Cloudinary) and read data into your app
        //*************************************************************************************************
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}
