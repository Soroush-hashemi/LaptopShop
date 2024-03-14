using Common.Application;
using Domain.Addresses.Repository;
using Domain.Addresses;
using Common.Domain.Exceptions;

namespace Application.Addresses.Create;
public class CreateAddressCommandHandler : IBaseCommandHandler<CreateAddressCommand>
{
    private readonly IAddressRepository _repository;
    public CreateAddressCommandHandler(IAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _repository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();

            var address = new Domain.Addresses.Address(request.UserId, request.NameOfRecipient,
                request.Province, request.City, request.PostalCode, request.AddressDetail, request.PhoneNumberForAddress);

            _repository.Add(address);
            await _repository.Save();
            return OperationResult.Success();
        }
        catch (NullOrEmptyException ex)
        {
            return OperationResult.Error(ex.Message);
        }
    }
}