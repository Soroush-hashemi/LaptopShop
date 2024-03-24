using Microsoft.AspNetCore.Mvc;
using PresentationFacade.Products;
using PresentationFacade.Products.Serivce;

namespace WebApplication.Areas.Admin.Controllers;
public class ProductController : AdminControllerBase
{
    private readonly IProductSerivce _service;
    private readonly IProductsFacade _productsFacade;
    public ProductController(IProductSerivce service, IProductsFacade productsFacade)
    {
        _service = service;
        _productsFacade = productsFacade;
    }

    public IActionResult Index()
    {
        return View();
    }
}