using Domain.Orders;
using PresentationFacade.ProductComment.Service.DTO;
using Query.Order.DTOs;
using WebApplication.Areas.Admin.Models.Comment;

namespace WebApplication.Areas.Admin.Models.Order;
public static class OrderMapper
{
    public static OrderViewModel MapToViewModel(this OrderDto dto)
    {
        return new OrderViewModel
        {
            Id = dto.Id,
            OrderDetailsId = dto.OrderDetailsId,
            OrderState = dto.OrderState.MapStateViewMode(),
            RequestPayId = dto.RequestPayId,
            UserId = dto.UserId,
            AddressId = dto.AddressId,
            UserName = dto.UserName,
            Price = dto.Price,
            TotalPrice = dto.TotalPrice,
            CreationDate = dto.CreationDate,
            OrderDetails = dto.OrderDetails != null ? dto.OrderDetails.Select(d => MapToViewModel(d)).ToList() : null
        };
    }

    public static OrderDetailsViewModel MapToViewModel(this OrderDetailsDto dto)
    {
        return new OrderDetailsViewModel
        {
            Id = dto.Id,
            OrderId = dto.OrderId,
            ProductId = dto.ProductId,
            ProductName = dto.ProductName,
            Price = dto.Price,
            Count = dto.Count,
            ProductSlug = dto.ProductSlug,
            OrderState = dto.OrderState,
            NameOfRecipient = dto.NameOfRecipient,
            Province = dto.Province,
            City = dto.City,
            PostalCode = dto.PostalCode,
            AddressDetail = dto.AddressDetail,
            PhoneNumberForAddress = dto.PhoneNumberForAddress,
            CreationDate = dto.CreationDate,
        };
    }

    public static OrderStateViewModel MapStateViewMode(this OrderState orderState)
    {
        switch (orderState)
        {
            case OrderState.Processing:
                return OrderStateViewModel.Processing;
            case OrderState.Canceled:
                return OrderStateViewModel.Canceled;
            case OrderState.Delivered:
                return OrderStateViewModel.Delivered;
            default:
                return OrderStateViewModel.Processing;
        }
    }

    public static List<OrderViewModel> MapList(this List<OrderDto> dto)
    {
        List<OrderViewModel> model = new List<OrderViewModel>();
        dto.ForEach(c => model.Add(c.MapToViewModel()));
        return model;
    }

    public static List<OrderDetailsViewModel> MapToDetailViewModelList(this List<OrderDetailsDto> dtos)
    {
        List<OrderDetailsViewModel> model = new List<OrderDetailsViewModel>();
        dtos.ForEach(c => model.Add(c.MapToViewModel()));
        return model;
    }
}
