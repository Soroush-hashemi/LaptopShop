using Microsoft.AspNetCore.Mvc;
using PresentationFacade.Sliders;
using WebApplication.Areas.Admin.Models.Sliders;

namespace WebApplication.Areas.Admin.Controllers;
public class SliderController : AdminControllerBase
{
    private readonly ISliderFacade _sliderFacade;
    public SliderController(ISliderFacade sliderFacade)
    {
        _sliderFacade = sliderFacade;
    }

    public async Task<IActionResult> Index()
    {
        var sliders = await _sliderFacade.GetList();
        return View(sliders.MapList());
    }

    [HttpGet("/Admin/Slider/Create")]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost("/Admin/Slider/Create")]
    public IActionResult Create(SliderViewModel viewModel)
    {
        var SliderCommand = viewModel.MapToCreateCommand();
        var result = _sliderFacade.Create(SliderCommand);

        if (result.Result.Status != Common.Application.OperationResultStatus.Success)
        {
            ErrorAlert($"{result.Result.Message}");
            return RedirectToAction();
        }

        SuccessAlert();
        return RedirectToAction("Index");
    }

    [Route("/Admin/Slider/Edit/{Id}")]
    public async Task<IActionResult> Edit(long Id)
    {
        var result = await _sliderFacade.GetById(Id);
        return View(result.MapDto());
    }

    [HttpPost("/Admin/Slider/Edit/{Id}")]
    public IActionResult Edit(long Id, SliderViewModel viewModel)
    {
        var SliderCommand = viewModel.MapToEditCommand();
        var result = _sliderFacade.Edit(SliderCommand);

        if (result.Result.Status != Common.Application.OperationResultStatus.Success)
        {
            ErrorAlert($"{result.Result.Message}");
            return RedirectToAction();
        }

        SuccessAlert();
        return RedirectToAction("Index");
    }

    [Route("/Admin/Slider/Delete/{Id}")]
    public IActionResult Delete(long Id)
    {
        var result = _sliderFacade.Delete(Id);

        if (result.Result.Status != Common.Application.OperationResultStatus.Success)
        {
            ErrorAlert($"{result.Result.Message}");
            return RedirectToAction();
        }

        SuccessAlert();
        return RedirectToAction("Index");
    }
}