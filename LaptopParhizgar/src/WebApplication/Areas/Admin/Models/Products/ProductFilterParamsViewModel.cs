namespace WebApplication.Areas.Admin.Models.Products;
public class ProductFilterParamsViewModel
{
    public string Title { get; set; }
    public string CategorySlug { get; set; }
    public int PageId { get; set; }
    public int Take { get; set; }
}