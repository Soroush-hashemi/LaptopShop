using Infrastructure.Repositories.Base;
using Domain.Addresses;
using Domain.Addresses.Repository;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories;
public class AddressRepository : BaseRepository<Address>, IAddressRepository
{
    public AddressRepository(LaptopParhizgerContext context) : base(context)
    {
    }
}