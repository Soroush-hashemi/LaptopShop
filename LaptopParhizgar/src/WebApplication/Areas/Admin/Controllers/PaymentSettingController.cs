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
        _service.SetPaymentToDisable();
        return Redirect("/Admin/PaymentSetting");
    }

    [Route("Admin/PaymentSetting/Enable")]
    public IActionResult Enable()
    {
        _service.SetPaymentToEnable();
        return Redirect("/Admin/PaymentSetting");
    }
}