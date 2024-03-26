using WebApplication.Areas.Admin.Models.Shared;

namespace WebApplication.Areas.Admin.Models.Products;
public class ProductFilterViewModel : BasePaginationViewModel
{
    public List<ProductViewModel> Product { get; set; }
    public ProductFilterParamsViewModel FilterParams { get; set; }
}