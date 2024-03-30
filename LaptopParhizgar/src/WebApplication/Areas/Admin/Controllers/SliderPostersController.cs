using Microsoft.AspNetCore.Mvc;
using PresentationFacade.SliderPosters;
using WebApplication.Areas.Admin.Models.SliderPosters;

namespace WebApplication.Areas.Admin.Controllers;
public class SliderPostersController : AdminControllerBase
{
    private readonly ISlidersPostersFacade _sliderPostersFacade;
    public SliderPostersController(ISlidersPostersFacade sliderPostersFacade)
    {
        _sliderPostersFacade = sliderPostersFacade;
    }

    public async Task<IActionResult> Index()
    {
        var sliderPoster = await _sliderPostersFacade.GetList();
        return View(sliderPoster.MapList());
    }

    [HttpGet("/Admin/SliderPosters/Add")]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost("/Admin/SliderPosters/Add")]
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

    [Route("/Admin/SliderPosters/Edit/{Id}")]
    public async Task<IActionResult> Edit(long Id)
    {
        var result = await _sliderPostersFacade.GetById(Id);
        return View(result.Map());
    }

    [HttpPost("/Admin/SliderPosters/Edit/{Id}")]
    public IActionResult Edit(SliderPosterViewModel viewModel)
    {
        var result = _sliderPostersFacade.Edit(viewModel.MapEdit());

        if (result.Result.Status != Common.Application.OperationResultStatus.Success)
        {
            ErrorAlert($"{result.Result.Message}");
            return RedirectToAction();
        }

        SuccessAlert();
        return RedirectToAction("Index");
    }

    [Route("/Admin/SliderPosters/Delete/{Id?}")]
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