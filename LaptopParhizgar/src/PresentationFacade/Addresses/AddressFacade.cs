using Application.Addresses.Create;
using Application.Addresses.Edit;
using Common.Application;
using MediatR;
using Query.Addresses.DTO;
using Query.Addresses.GetById;

namespace PresentationFacade.Addresses;
public class AddressFacade : IAddressFacade
{
    private readonly IMediator _mediator;
    public AddressFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> Create(CreateAddressCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditAddressesCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<AddressDto> GetById(long AddressId)
    {
        return await _mediator.Send(new GetAdderssByIdQuery(AddressId));
    }
}