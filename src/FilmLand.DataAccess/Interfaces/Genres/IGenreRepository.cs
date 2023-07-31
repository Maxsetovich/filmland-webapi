using FilmLand.DataAccess.Common.Interfaces;
using FilmLand.Domain.Entities.Genres;

namespace FilmLand.DataAccess.Interfaces.Genres;

public interface IGenreRepository : IRepository<Genre, Genre>,
    IGetAll<Genre>
{

}

