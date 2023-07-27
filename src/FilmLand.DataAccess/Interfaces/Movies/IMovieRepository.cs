using FilmLand.DataAccess.Common.Interfaces;
using FilmLand.DataAccess.ViewModels.Movies;
using FilmLand.Domain.Entities.Movies;

namespace FilmLand.DataAccess.Interfaces.Movies;

public interface IMovieRepository : IRepository<Movie, Movie>,
    IGetAll<MovieViewModel>, ISearchable<MovieViewModel>
{

}
