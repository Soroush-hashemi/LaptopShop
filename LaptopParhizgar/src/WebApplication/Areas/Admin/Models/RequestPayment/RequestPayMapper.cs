using PresentationFacade.RequestPayment.Service.DTO;

namespace WebApplication.Areas.Admin.Models.RequestPayment;
public static class RequestPayMapper
{
    public static RequestPayFilterParams MapParam(this RequestPayFilterParamsViewModel filterParams)
    {
        return new RequestPayFilterParams()
        {
            Take = filterParams.Take,
            PageId = filterParams.PageId,
        };
    }

    public static RequestPayFilterParamsViewModel MapParamDto(this RequestPayFilterParams filterParams)
    {
        return new RequestPayFilterParamsViewModel()
        {
            Take = filterParams.Take,
            PageId = filterParams.PageId,
        };
    }

    public static RequestPayFilterViewModel Map(this RequestPayFilterDto dto)
    {
        return new RequestPayFilterViewModel()
        {
            EntityCount = dto.EntityCount,
            EndPage = dto.EndPage,
            StartPage = dto.StartPage,
            Take = dto.Take,
            CurrentPage = dto.CurrentPage,
            FilterParams = dto.FilterParams.MapParamDto(),
            RequestPay = dto.RequestPay.MapListDto(),
            PageCount = dto.PageCount,
        };
    }

    public static RequestPayDto Map(this RequestPayViewModel viewModel)
    {
        return new RequestPayDto()
        {
            Id = viewModel.Id,
            CreationDate = viewModel.CreationDate,
            guid = viewModel.guid,
            Amount = viewModel.Amount,
            UserId = viewModel.UserId,
            Username = viewModel.Username,
            Fullname = viewModel.Fullname,
            PhoneNumber = viewModel.PhoneNumber,
            Email = viewModel.Email,
            IsPay = viewModel.IsPay,
        };
    }

    public static RequestPayViewModel MapDto(this RequestPayDto dto)
    {
        return new RequestPayViewModel()
        {
            Id = dto.Id,
            CreationDate = dto.CreationDate,
            guid = dto.guid,
            Amount = dto.Amount,
            UserId = dto.UserId,
            Username = dto.Username,
            Fullname = dto.Fullname,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            IsPay = dto.IsPay,
        };
    }

    public static List<RequestPayDto> MapList(this List<RequestPayViewModel> viewModel)
    {
        List<RequestPayDto> model = new List<RequestPayDto>();
        viewModel.ForEach(c => model.Add(c.Map()));
        return model;
    }

    public static List<RequestPayViewModel> MapListDto(this List<RequestPayDto> dto)
    {
        List<RequestPayViewModel> model = new List<RequestPayViewModel>();
        dto.ForEach(c => model.Add(c.MapDto()));
        return model;
    }
}