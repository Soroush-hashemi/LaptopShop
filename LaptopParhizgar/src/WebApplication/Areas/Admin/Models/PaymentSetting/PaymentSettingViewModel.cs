using PresentationFacade.PaymentSetting.Service.DTO;

namespace WebApplication.Areas.Admin.Models.PaymentSetting;
public class PaymentSettingViewModel
{
    public bool PaymentStatus { get; set; }
}

public static class PaymentSettingMapper
{
    public static PaymentSettingViewModel Map(this PaymentSettingDto dto)
    {
        return new PaymentSettingViewModel
        {
            PaymentStatus = dto.PaymentStatus,
        };
    }
}