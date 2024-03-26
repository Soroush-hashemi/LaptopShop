using Microsoft.AspNetCore.Mvc;
using PresentationFacade.RequestPayment.Service;
using PresentationFacade.RequestPayment.Service.DTO;
using WebApplication.Areas.Admin.Models.RequestPayment;

namespace WebApplication.Areas.Admin.Controllers;
public class RequestPaymentController : AdminControllerBase
{
    private readonly IRequestPaymentService _service;
    public RequestPaymentController(IRequestPaymentService service)
    {
        _service = service;
    }

    public IActionResult Index(int pageId = 1)
    {
        var param = new RequestPayFilterParams()
        {
            PageId = pageId,
            Take = 10,
        };
        var Model = _service.GetRequestPayByFilter(param);
        return View(Model.Map());
    }

    [Route("/Admin/RequestPay/Check/{RequestPayId}")]
    public IActionResult Check(int RequestPayId)
    {
        var requestPay = _service.GetRequestPayDetail(RequestPayId);
        var model = requestPay.MapDto();
        return View(model);
    }

}