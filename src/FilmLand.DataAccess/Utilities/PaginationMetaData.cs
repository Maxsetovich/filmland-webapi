namespace FilmLand.DataAccess.Utilities;

public class PaginationMetaData
{
    public bool HasPrevious { get; set; }

    public bool HasNext { get; set; }

    public int CurentPage { get; set; }

    public int Totalpages { get; set; }

    public int PageSize { get; set; }

    public int TotalItems { get; set; }
}
