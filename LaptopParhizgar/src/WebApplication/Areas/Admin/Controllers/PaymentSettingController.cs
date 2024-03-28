using Microsoft.AspNetCore.Mvc;
using PresentationFacade.PaymentSetting.Service;
using WebApplication.Areas.Admin.Models.PaymentSetting;

namespace WebApplication.Areas.Admin.Controllers;
public class PaymentSettingController : AdminControllerBase
{
    private readonly IPaymentSettingService _service;
    public PaymentSettingController(IPaymentSettingService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        var paymentSetting = _service.GetPaymentSetting();
        return View(paymentSetting.Map());
    }

    [Route("Admin/PaymentSetting/Disable")]
    public IActionResult Disable()
    {
        var result = _service.SetPaymentToDisable();
        if (result.Status != Common.Application.OperationResultStatus.Success)
        {
            ErrorAlert($"{result.Message}");
            return RedirectToAction();
        }

        SuccessAlert();
        return RedirectToAction("Index");
    }

    [Route("Admin/PaymentSetting/Enable")]
    public IActionResult Enable()
    {
        var result = _service.SetPaymentToEnable();
        if (result.Status != Common.Application.OperationResultStatus.Success)
        {
            ErrorAlert($"{result.Message}");
            return RedirectToAction();
        }

        SuccessAlert();
        return RedirectToAction("Index");
    }
}