using FilmLand.DataAccess.Common.Interfaces;
using FilmLand.Domain.Entities.Countries;

namespace FilmLand.DataAccess.Interfaces.Countries;

public  interface ICountryRepository : IRepository<Country, Country>,
    IGetAll<Country>
{
}
