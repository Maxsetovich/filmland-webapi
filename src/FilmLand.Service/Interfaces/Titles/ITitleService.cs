using FilmLand.DataAccess.Utilities;
using FilmLand.Domain.Entities.Titles;
using FilmLand.Service.Dtos.Titles;

namespace FilmLand.Service.Interfaces.Titles;

public interface ITitleService
{
    public Task<bool> CreateAsync(TitleCreateDto dto);

    public Task<bool> DeleteAsync(long titleId);

    public Task<long> CountAsync();

    public Task<IList<Title>> GetAllAsync(PaginationParams @params);

    public Task<Title> GetByIdAsync(long titleId);

    public Task<bool> UpdateAsync(long titleId, TitleUpdateDto dto);
}
