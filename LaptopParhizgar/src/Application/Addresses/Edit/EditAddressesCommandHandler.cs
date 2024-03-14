using Common.Application;
using Common.Domain.Exceptions;
using Domain.Addresses.Repository;

namespace Application.Addresses.Edit;
public class EditAddressesCommandHandler : IBaseCommandHandler<EditAddressesCommand>
{
    private readonly IAddressRepository _repository;
    public EditAddressesCommandHandler(IAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(EditAddressesCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var address = await _repository.GetTracking(request.AddressId);

            address.Edit(request.NameOfRecipient, request.Province, request.City,
                request.PostalCode, request.AddressDetail, request.PhoneNumberForAddress);

            await _repository.Save();
            return OperationResult.Success();
        }
        catch (NullOrEmptyException ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }
}