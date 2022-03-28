namespace FantasySky.Core.Operation;

public class PageOperationalResult<T> : OperationalResult<IEnumerable<T>>
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public long Total { get; set; }
}
