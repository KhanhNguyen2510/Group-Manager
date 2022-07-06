using Microsoft.AspNetCore.Mvc;

namespace GM.API.Models.Common;

public class QueryParameter
{
    private const int MaxPageCount = 100;

    private int _pageCount = MaxPageCount;

    [FromQuery(Name = "page")] public int Page { get; set; } = 1;

    [FromQuery(Name = "page_count")]
    public int PageCount
    {
        get => _pageCount;
        set => _pageCount = value > MaxPageCount ? MaxPageCount : value;
    }

    [FromQuery(Name = "order_by")] public string OrderBy { get; set; } = "CreatedAt desc";

    public int Skip()
    {
        return PageCount * (Page - 1);
    }
}
