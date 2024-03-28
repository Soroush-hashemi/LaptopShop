using Microsoft.AspNetCore.Mvc;
using PresentationFacade.SliderPosters;
using WebApplication.Areas.Admin.Models.SliderPosters;

namespace WebApplication.Areas.Admin.Controllers;
public class SliderPostersController : AdminControllerBase
{
    private readonly ISliderPostersFacade _sliderPostersFacade;
    public SliderPostersController(SliderPostersFacade sliderPostersFacade)
    {
        _sliderPostersFacade = sliderPostersFacade;
    }

    public async Task<IActionResult> Index()
    {
        var sliderPoster = await _sliderPostersFacade.GetList();
        return View(sliderPoster.MapList());
    }

    [HttpGet("/Admin/SliderPoster/Add")]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost("/Admin/SliderPoster/Add")]
    public async Task<IActionResult> Add(SliderPosterViewModel viewModel)
    {
        var result = await _sliderPostersFacade.Create(viewModel.MapCreate());

        if (result.Status != Common.Application.OperationResultStatus.Success)
        {
            ErrorAlert($"{result.Message}");
            return RedirectToAction();
        }

        SuccessAlert();
        return RedirectToAction("Index");
    }

    [HttpGet("/Admin/SliderPoster/Edit")]
    public IActionResult Edit()
    {
        return View();
    }

    [HttpPost("/Admin/SliderPoster/Edit")]
    public async Task<IActionResult> Edit(SliderPosterViewModel viewModel)
    {
        var result = await _sliderPostersFacade.Edit(viewModel.MapEdit());

        if (result.Status != Common.Application.OperationResultStatus.Success)
        {
            ErrorAlert($"{result.Message}");
            return RedirectToAction();
        }

        SuccessAlert();
        return RedirectToAction("Index");
    }

    [Route("/Admin/SliderPoster/Delete/{Id?}")]
    public async Task<IActionResult> Delete(long Id)
    {
        var result = await _sliderPostersFacade.Delete(Id.MapDelete());

        if (result.Status != Common.Application.OperationResultStatus.Success)
        {
            ErrorAlert($"{result.Message}");
            return RedirectToAction();
        }

        SuccessAlert();
        return RedirectToAction("Index");
    }

}