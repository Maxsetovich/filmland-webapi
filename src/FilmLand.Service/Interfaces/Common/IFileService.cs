using Microsoft.AspNetCore.Http;

namespace FilmLand.Service.Interfaces.Common;

public interface IFileService
{
    // returns sub path of this image
    public Task<string> UploadImageAsync(IFormFile image);

    public Task<bool> DeleteImageAsync(string subpath);

    // returns sub path of this avatar
    public Task<string> UploadAvatarAsync(IFormFile avatar);

    public Task<bool> DeleteAvatarAsync(string subpath);

    // returns sub path of this movie
    public Task<string> UploadMovieAsync(IFormFile movie);

    public Task<bool> DeleteMovieAsync(string subpath);

    // returns sub path of this trailer
    public Task<string> UploadTrailerAsync(IFormFile trailer);

    public Task<bool> DeleteTrailerAsync(string subpath);

}
