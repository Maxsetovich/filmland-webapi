using FilmLand.DataAccess.Common.Interfaces;
using FilmLand.Domain.Entities.Languages;
using FilmLand.Domain.Entities.Titles;

namespace FilmLand.DataAccess.Interfaces.Titles;

public interface ITitleRepository : IRepository<Title, Title>,
    IGetAll<Title>
{
}
