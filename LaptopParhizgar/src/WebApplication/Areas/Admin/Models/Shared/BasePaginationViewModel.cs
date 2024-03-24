namespace WebApplication.Areas.Admin.Models.Shared;
public class BasePaginationViewModel
{
    public int PageCount { get; set; }
    public int EntityCount { get; set; }
    public int CurrentPage { get; set; }
    public int StartPage { get; set; }
    public int EndPage { get; set; }
    public int Take { get; set; }
}