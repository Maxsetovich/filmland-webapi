using FilmLand.DataAccess.Utilities;
using FilmLand.Domain.Entities.Companies;
using FilmLand.Service.Dtos.Companies;

namespace FilmLand.Service.Interfaces.Companies;

public interface ICompanyService
{
    public Task<bool> CreateAsync(CompanyCreateDto dto);

    public Task<bool> DeleteAsync(long companyId);

    public Task<long> CountAsync();

    public Task<IList<Company>> GetAllAsync(PaginationParams @params);

    public Task<Company> GetByIdAsync(long companyId);

    public Task<bool> UpdateAsync(long companyId, CompanyUpdateDto dto);
}
