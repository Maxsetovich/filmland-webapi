using FilmLand.Service.Common.Helpers;
using FilmLand.Service.Interfaces.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace FilmLand.Service.Services.Common;

public class FileService : IFileService
{
    private readonly string MEDIA = "media";
    private readonly string IMAGES = "images";
    private readonly string MOVIES = "movies";
    private readonly string TRAILERS = "trailers";
    private readonly string AVATARS = "avatars";
    private readonly string ROOTPATH;
    public FileService(IWebHostEnvironment env)
    {
        ROOTPATH = env.WebRootPath;
    }

    public async Task<bool> DeleteImageAsync(string subpath)
    {
        string path = Path.Combine(ROOTPATH, subpath);
        if (File.Exists(path))
        {
            await Task.Run(() =>
            {
                File.Delete(path);
            });
            return true;
        }
        else return false;
    }

    public async Task<string> UploadImageAsync(IFormFile image)
    {
        string newImageName = MediaHelper.MakeImageName(image.FileName);
        string subpath = Path.Combine(MEDIA, IMAGES, newImageName);
        string path = Path.Combine(ROOTPATH, subpath);

        var stream = new FileStream(path, FileMode.Create);
        await image.CopyToAsync(stream);
        stream.Close();

        return subpath;
    }

    public Task<bool> DeleteAvatarAsync(string subpath)
    {
        throw new NotImplementedException();
    }

    public Task<string> UploadAvatarAsync(IFormFile avatar)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteMovieAsync(string subpath)
    {
        string path = Path.Combine(ROOTPATH, subpath);
        if (File.Exists(path))
        {
            await Task.Run(() =>
            {
                File.Delete(path);
            });
            return true;
        }
        else return false;
    }

    public async Task<string> UploadMovieAsync(IFormFile movie)
    {
        string newMovieName = MediaHelper.MakeMovieName(movie.FileName);
        string subpath = Path.Combine(MEDIA, MOVIES, newMovieName);
        string path = Path.Combine(ROOTPATH, subpath);

        var stream = new FileStream(path, FileMode.Create);
        await movie.CopyToAsync(stream);
        stream.Close();

        return subpath;
    }

    public async Task<bool> DeleteTrailerAsync(string subpath)
    {
        string path = Path.Combine(ROOTPATH, subpath);
        if (File.Exists(path))
        {
            await Task.Run(() =>
            {
                File.Delete(path);
            });
            return true;
        }
        else return false;
    }

    public async Task<string> UploadTrailerAsync(IFormFile trailer)
    {
        string newTrailerName = MediaHelper.MakeTrailerName(trailer.FileName);
        string subpath = Path.Combine(MEDIA, TRAILERS, newTrailerName);
        string path = Path.Combine(ROOTPATH, subpath);

        var stream = new FileStream(path, FileMode.Create);
        await trailer.CopyToAsync(stream);
        stream.Close();

        return subpath;
    }
}
