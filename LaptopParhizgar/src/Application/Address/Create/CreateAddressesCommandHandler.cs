using Common.Application;
using Domain.Address.Repository;
using Domain.Address;
using Common.Domain.Exceptions;

namespace Application.Address.Create;
public class CreateAddressesCommandHandler : IBaseCommandHandler<CreateAddressesCommand>
{
    private readonly IAddressRepository _repository;
    public CreateAddressesCommandHandler(IAddressRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(CreateAddressesCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _repository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();

            var address = new Addresses(request.UserId, request.NameOfRecipient,
                request.Province, request.City, request.PostalCode, request.Address, request.PhoneNumberForAddress);

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