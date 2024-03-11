using Infrastructure.Repositories.Base;
using Domain.Address;
using Domain.Address.Repository;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories;
public class AddressRepository : BaseRepository<Addresses>, IAddressRepository
{
    public AddressRepository(LaptopParhizgerContext context) : base(context)
    {
    }
}