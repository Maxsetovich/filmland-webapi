using FilmLand.DataAccess.Common.Interfaces;
using FilmLand.Domain.Entities.Companies;

namespace FilmLand.DataAccess.Interfaces.Companies;

public interface ICompanyRepository : IRepository<Company, Company>,
    IGetAll<Company>
{
}
