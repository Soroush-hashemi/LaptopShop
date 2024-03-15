using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Query.Payment.DTO;

namespace Query.Payment.Service;
public class RequestPaymentService : IPaymentSettingService
{
    private readonly LaptopParhizgerContext _context;
    public RequestPaymentService(LaptopParhizgerContext context)
    {
        _context = context;
    }

    public RequestPayDto GetRequestPay(Guid guid)
    {
        var requestPayIsExist = _context.RequestPay.Any(p => p.Guid == guid);
        if (requestPayIsExist == true)
        {
            var requestPay = _context.RequestPay.Where(p => p.Guid == guid).FirstOrDefault();
            return new RequestPayDto()
            {
                Amount = requestPay.Amount,
                Id = requestPay.Id,
                CreationDate = requestPay.CreationDate,
            };
        }
        else
        {
            throw new Exception("درخواست پرداخت پیدا نشد");
        }
    }

    public RequestPayFilterDto GetRequestPayByFilter(RequestPayFilterParams filterParams)
    {
        var result = _context.RequestPay.OrderByDescending(d => d.CreationDate)
            .AsQueryable();

        foreach (var item in result)
        {
            var user = _context.Users.FirstOrDefault(p => p.Id == item.UserId);
            string UserName = user.UserName;
            string PhoneNumber = user.PhoneNumber.Value;

            var skip = (filterParams.PageId - 1) * filterParams.Take;
            var model = new RequestPayFilterDto()
            {
                RequestPay = result.Skip(skip).Take(filterParams.Take)
                .Select(RequestPay => RequestPayMapper.MapToDto(RequestPay, UserName, PhoneNumber)).ToList(),
                FilterParams = filterParams,
            };
            model.GeneratePaging(result, filterParams.Take, filterParams.PageId);

            return model;
        }
        return new RequestPayFilterDto();
    }

    public RequestPayDto GetRequestPayDetail(int RequestPayId)
    {
        var RequestPay = _context.RequestPay.Where(p => p.Id == RequestPayId).FirstOrDefault();
        var User = _context.Users.Where(p => p.Id == RequestPay.UserId).FirstOrDefault();
        return new RequestPayDto
        {
            guid = RequestPay.Guid,
            IsPay = RequestPay.IsPay,
            Username = User.UserName,
            PhoneNumber = User.PhoneNumber.Value,
            Email = User.Email,
            Fullname = User.FullName,
        };
    }
}