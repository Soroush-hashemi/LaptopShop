using Application.Products.Delete;
using Microsoft.AspNetCore.Mvc;
using PresentationFacade.Products;
using PresentationFacade.Products.Serivce;
using Query.Products.GetById;
using WebApplication.Areas.Admin.Models.Products;

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

    public IActionResult Index(int pageId = 1, string title = "", string categorySlug = "")
    {
        var param = new ProductFilterParamsViewModel()
        {
            CategorySlug = categorySlug,
            PageId = pageId,
            Take = 10,
            Title = title
        };

        var Model = _service.GetProductByFilter(param.MapParamViewModel());
        return View(Model.MapFilter());
    }

    [Route("/Admin/Product/Create/{Id?}")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("/Admin/Product/Create")]
    public async Task<IActionResult> Create(ProductViewModel createViewModel)
    {
        var productCommand = createViewModel.MapToCreate();
        var result = await _productsFacade.Create(productCommand);

        if (result.Status != Common.Application.OperationResultStatus.Success)
        {
            ErrorAlert($"{result.Message}");
            return RedirectToAction();
        }

        SuccessAlert();
        return RedirectToAction("Index");
    }

    [Route("/Admin/Product/Edit/{Id?}")]
    public async Task<IActionResult> Edit(long Id)
    {
        var product = await _productsFacade.GetById(new GetProductByIdQuery(Id));
        var result = product.Map();
        return View(result);
    }

    [HttpPost("/Admin/Product/Edit/{Id?}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(long Id, ProductViewModel ViewModel)
    {
        ViewModel.Id = Id;
        var productCommand = ViewModel.MapToEdit();
        var result = await _productsFacade.Edit(productCommand);

        if (result.Status != Common.Application.OperationResultStatus.Success)
        {
            ErrorAlert($"{result.Message}");
            return RedirectToAction();
        }

        SuccessAlert();
        return RedirectToAction("Index");
    }

    [Route("/Admin/Product/Delete/{Id}")]
    public async Task<IActionResult> Delete(long Id)
    {
        var result = await _productsFacade.Delete(Id);

        if (result.Status != Common.Application.OperationResultStatus.Success)
        {
            ErrorAlert($"{result.Message}");
            return RedirectToAction();
        }

        SuccessAlert();
        return RedirectToAction("Index");
    }

}