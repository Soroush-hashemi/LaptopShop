using Common.Domain.Bases;

namespace Common.Domain.Exceptions;
public class ProductIsNotEnoughException : BaseDomainException
{
    public ProductIsNotEnoughException()
    {
        
    }

    public ProductIsNotEnoughException(string message) : base(message)
    {
        
    }
}