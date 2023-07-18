using FilmLand.DataAccess.Common.Interfaces;
using FilmLand.Domain.Entities.Languages;

namespace FilmLand.DataAccess.Interfaces.Languages;

public interface ILanguageRepository : IRepository<Language, Language>,
    IGetAll<Language>
{
}
