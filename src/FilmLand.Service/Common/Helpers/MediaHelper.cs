namespace FilmLand.Service.Common.Helpers;

public class MediaHelper
{
    public static string MakeImageName(string fileName)
    {
        FileInfo fileInfo = new FileInfo(fileName);
        string extension = fileInfo.Extension;
        string name = "IMG_" + Guid.NewGuid() + extension;
        return name;
    }

    public static string[] GetImageExtensions()
    {
        return new string[]
        {
            // JPG files
            ".jpg", ".jpeg",
            // PNG files
            ".png",
            // BMP files
            ".bmp",
            // SVG files
            ".svg"
        };
    }

    public static string MakeMovieName(string fileName)
    {
        FileInfo fileInfo = new FileInfo(fileName);
        string extension = fileInfo.Extension;
        string name = "Movie_" + Guid.NewGuid() + extension;
        return name;
    }

    public static string[] GetMovieExtensions()
    {
        return new string[]
        {
            // MP4 files
            ".mp4", "MP4",
            // AVI files
            ".avi", ".AVI",
            // MOV files
            ".mov", ".MOV",
            // WMV files
            ".wmv", ".WMV",
            // MKV files
            ".mkv", ".MKV"
        };
    }

    public static string MakeTrailerName(string fileName)
    {
        FileInfo fileInfo = new FileInfo(fileName);
        string extension = fileInfo.Extension;
        string name = "Trailer_" + Guid.NewGuid() + extension;
        return name;
    }

    public static string[] GetTrailerExtensions()
    {
        return new string[]
        {
            // MP4 files
            ".mp4", "MP4",
            // AVI files
            ".avi", ".AVI",
            // MOV files
            ".mov", ".MOV",
            // WMV files
            ".wmv", ".WMV",
            // MKV files
            ".mkv", ".MKV"
        };
    }
}
