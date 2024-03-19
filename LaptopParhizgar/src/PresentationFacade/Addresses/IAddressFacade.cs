using Application.Addresses.Create;
using Application.Addresses.Edit;
using Common.Application;
using Query.Addresses.DTO;

namespace PresentationFacade.Addresses;
public interface IAddressFacade 
{
    Task<OperationResult> Create(CreateAddressCommand command);
    Task<OperationResult> Edit(EditAddressesCommand command);

    Task<AddressDto> GetById(long AddressId);
}