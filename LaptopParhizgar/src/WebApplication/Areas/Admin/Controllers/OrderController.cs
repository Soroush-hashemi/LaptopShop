using Microsoft.AspNetCore.Mvc;
using PresentationFacade.Order;
using WebApplication.Areas.Admin.Models.Order;

namespace WebApplication.Areas.Admin.Controllers;
public class OrderController : AdminControllerBase
{
    private readonly IOrderFacade _orderFacade;
    public OrderController(IOrderFacade orderFacade)
    {
        _orderFacade = orderFacade;
    }

    public async Task<IActionResult> Index()
    {
        var orders = await _orderFacade.GetAllOrders();
        var orderViewModels = orders.MapList();
        return View(orderViewModels);
    }

    [HttpGet("/Admin/Order/Details/{OrderId}")]
    public async Task<IActionResult> Details(long OrderId)
    {
        var orderDetails = await _orderFacade.GetByOrderId(OrderId);
        var orderDetailsViewModels = orderDetails.MapToDetailViewModelList();
        return View(orderDetailsViewModels);
    }

    [Route("/Admin/Order/Delivered/{OrderId}")]
    public IActionResult Delivered(int OrderId)
    {
        var result = _orderFacade.SetOrderStateOnDelivered(OrderId);

        if (result.Result.Status != Common.Application.OperationResultStatus.Success)
        {
            ErrorAlert($"{result.Result.Message}");
            return RedirectToAction();
        }

        SuccessAlert();
        return RedirectToAction("Index");
    }

    [Route("/Admin/Order/Canceled/{OrderId}")]
    public IActionResult Canceled(int OrderId)
    {
        var result =  _orderFacade.SetOrderStateOnCanceled(OrderId);

        if (result.Result.Status != Common.Application.OperationResultStatus.Success)
        {
            ErrorAlert($"{result.Result.Message}");
            return RedirectToAction();
        }

        SuccessAlert();
        return RedirectToAction("Index");
    }

}