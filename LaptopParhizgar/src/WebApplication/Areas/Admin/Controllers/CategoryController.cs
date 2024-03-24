using Microsoft.AspNetCore.Mvc;
using PresentationFacade.Categories;
using WebApplication.Areas.Admin.Models.Categories;

namespace WebApplication.Areas.Admin.Controllers;
public class CategoryController : AdminControllerBase
{
    private readonly ICategoryFacade _categoryFacade;
    public CategoryController(ICategoryFacade categoryFacade)
    {
        _categoryFacade = categoryFacade;
    }

    public async Task<IActionResult> Index()
    {
        var categoriesDto = await _categoryFacade.GetList();
        return View(categoriesDto.MapList());
    }

    [Route("/Admin/category/Create/{categoryId?}")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("/Admin/category/Create")]
    public IActionResult Create(CategoryViewModel createViewModel)
    {
        var categoryCommand = createViewModel.MapToCreateCommand();
        var result = _categoryFacade.Create(categoryCommand);

        if (result.Result.Status != Common.Application.OperationResultStatus.Success)
        {
            ErrorAlert($"{result.Result.Message}");
            return RedirectToAction();
        }

        SuccessAlert();
        return RedirectToAction("Index");
    }

    [Route("/Admin/category/Edit/{Id?}")]
    public async Task<IActionResult> Edit(long Id)
    {
        var categorydto = await _categoryFacade.GetById(Id);

        return View(categorydto.MapDto());
    }

    [HttpPost("/Admin/category/Edit/{Id}")]
    public IActionResult Edit(long Id, CategoryViewModel ViewModel)
    {
        ViewModel.Id = Id;
        var categoryCommand = ViewModel.MapToEditCommand();
        var result = _categoryFacade.Edit(categoryCommand);

        if (result.Result.Status != Common.Application.OperationResultStatus.Success)
        {
            ErrorAlert($"{result.Result.Message}");
            return View();
        }

        SuccessAlert();
        return RedirectToAction("Index");
    }

    [Route("/Admin/category/Delete/{Id}")]
    public IActionResult Delete(long Id)
    {
        var categoryCommand = Id;
        var result = _categoryFacade.Delete(categoryCommand);

        if (result.Result.Status != Common.Application.OperationResultStatus.Success)
        {
            ErrorAlert($"{result.Result.Message}");
            return RedirectToAction();
        }

        SuccessAlert();
        return RedirectToAction("Index");
    }

    [Route("/Admin/category/AddChild/{parentId?}")]
    public IActionResult AddChild(int parentId)
    {
        return View();
    }

    [HttpPost("/Admin/category/AddChild/{parentId}")]
    public IActionResult AddChild(int parentId, ChildCategoryViewModel createViewModel)
    {
        createViewModel.ParentId = parentId;
        var categoryCommand = createViewModel.MapToAddChildCommand();
        var result = _categoryFacade.AddChild(categoryCommand);

        if (result.Result.Status != Common.Application.OperationResultStatus.Success)
        {
            ErrorAlert($"{result.Result.Message}");
            return RedirectToAction();
        }

        SuccessAlert();
        return RedirectToAction("Index");
    }

    [Route("/Admin/category/GetChildCategories/{parentId?}")]
    public async Task<IActionResult> GetChildCategories(int parentId)
    {
        var categoy = await _categoryFacade.GetByParentId(parentId);
        return new JsonResult(categoy);
    }
}