using Application.Products.Delete;
using Microsoft.AspNetCore.Mvc;
using PresentationFacade.Products;
using PresentationFacade.Products.Serivce;
using Query.Products.DTOs;
using Query.Products.GetById;
using WebApplication.Areas.Admin.Models.Product;

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
        var param = new ProductFilterParams()
        {
            CategorySlug = categorySlug,
            PageId = pageId,
            Take = 10,
            Title = title
        };
        var Model = _service.GetProductByFilter(param);
        return View(Model);
    }

    [Route("/Admin/Product/Create/{Id?}")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("/Admin/Product/Create")]
    public IActionResult Create(ProductViewModel createViewModel)
    {
        var productCommand = createViewModel.MapToCreate();
        var result = _productsFacade.Create(productCommand);

        if (result.Result.Status != Common.Application.OperationResultStatus.Success)
        {
            ErrorAlert($"{result.Result.Message}");
            return RedirectToAction();
        }

        SuccessAlert();
        return RedirectToAction("Index");
    }

    [Route("/Admin/Product/Edit/{Id?}")]
    public async Task<IActionResult> Edit(long Id)
    {
        var result = await _productsFacade.GetById(new GetProductByIdQuery(Id));
        return View(result.Map());
    }

    [HttpPost("/Admin/Product/Edit/{Id}")]
    public IActionResult Edit(long Id, ProductViewModel ViewModel)
    {
        ViewModel.Id = Id;
        var productCommand = ViewModel.MapToEdit();
        var result = _productsFacade.Edit(productCommand);

        if (result.Result.Status != Common.Application.OperationResultStatus.Success)
        {
            ErrorAlert($"{result.Result.Message}");
            return RedirectToAction();
        }

        SuccessAlert();
        return RedirectToAction("Index");
    }

    [Route("/Admin/Product/Delete/{Id}")]
    public IActionResult Delete(long Id)
    {
        var result = _productsFacade.Delete(new DeleteProductCommand(Id));

        if (result.Result.Status != Common.Application.OperationResultStatus.Success)
        {
            ErrorAlert($"{result.Result.Message}");
            return RedirectToAction();
        }

        SuccessAlert();
        return RedirectToAction("Index");
    }

}