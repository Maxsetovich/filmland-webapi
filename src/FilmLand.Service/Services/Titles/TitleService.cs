using FilmLand.DataAccess.Interfaces.Titles;
using FilmLand.DataAccess.Utilities;
using FilmLand.Domain.Entities.Titles;
using FilmLand.Domain.Exceptions.Titles;
using FilmLand.Service.Common.Helpers;
using FilmLand.Service.Dtos.Titles;
using FilmLand.Service.Interfaces.Common;
using FilmLand.Service.Interfaces.Titles;

namespace FilmLand.Service.Services.Titles;

public class TitleService : ITitleService
{
    private readonly ITitleRepository _repository;
    private readonly IPaginator _paginator;

    public TitleService(ITitleRepository titleRepository,
        IPaginator paginator)
    {
        this._repository = titleRepository;
        this._paginator = paginator;
    }

    public async Task<long> CountAsync() => await _repository.CountAsync();

    public async Task<bool> CreateAsync(TitleCreateDto dto)
    {
        Title title = new Title()
        {
            Name = dto.Name,
            CreatedAt = TimeHelper.GetDateTime(),
            UpdatedAt = TimeHelper.GetDateTime()
        };
        var result = await _repository.CreateAsync(title);
        return result > 0;
    }

    public async Task<bool> DeleteAsync(long titleId)
    {
        var title = await _repository.GetByIdAsync(titleId);
        if (title is null) throw new TitleNotFoundException();

        var dbResult = await _repository.DeleteAsync(titleId);
        return dbResult > 0;
    }

    public async Task<IList<Title>> GetAllAsync(PaginationParams @params)
    {
        var titles = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return titles;
    }

    public async Task<Title> GetByIdAsync(long titleId)
    {
        var title = await _repository.GetByIdAsync(titleId);
        if (title is null) throw new TitleNotFoundException();
        else return title;
    }

    public async Task<bool> UpdateAsync(long titleId, TitleUpdateDto dto)
    {
        var title = await _repository.GetByIdAsync(titleId);
        if (title is null) throw new TitleNotFoundException();

        // parse new items to title
        title.Name = dto.Name;

        title.UpdatedAt = TimeHelper.GetDateTime();

        var dbResult = await _repository.UpdateAsync(titleId, title);
        return dbResult > 0;
    }

}
