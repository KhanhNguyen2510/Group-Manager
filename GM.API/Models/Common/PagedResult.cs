namespace GM.API.Models.Common;

public class PagedResult<T> : PagedResultBase
{
    public List<T> Items { get; set; }
}
