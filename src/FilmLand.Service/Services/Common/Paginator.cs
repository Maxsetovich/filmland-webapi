using FilmLand.DataAccess.Utilities;
using FilmLand.Service.Interfaces.Common;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FilmLand.Service.Services.Common;

public class Paginator : IPaginator
{
    private readonly IHttpContextAccessor _accessor;

    public Paginator(IHttpContextAccessor httpContextAccessor)
    {
        this._accessor = httpContextAccessor;
    }
    public void Paginate(long itemsCount, PaginationParams @params)
    {
        PaginationMetaData paginationMetaData = new PaginationMetaData();
        paginationMetaData.CurentPage = @params.PageNumber;
        paginationMetaData.TotalItems = (int)itemsCount;
        paginationMetaData.PageSize = @params.PageSize;

        paginationMetaData.Totalpages = (int)Math.Ceiling((double)itemsCount / @params.PageSize);
        paginationMetaData.HasPrevious = paginationMetaData.CurentPage > 1;
        paginationMetaData.HasNext = paginationMetaData.CurentPage < paginationMetaData.Totalpages;

        string jsonContent = JsonConvert.SerializeObject(paginationMetaData);
        _accessor.HttpContext!.Response.Headers.Add("X-Pagination", jsonContent);
    }
}

