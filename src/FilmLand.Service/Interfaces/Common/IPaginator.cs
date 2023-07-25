using FilmLand.DataAccess.Utilities;

namespace FilmLand.Service.Interfaces.Common;

public interface IPaginator
{
    public void Paginate(long itemsCount, PaginationParams @params);
}
