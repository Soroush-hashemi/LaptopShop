namespace Common.Domain.Bases;
public class BaseDomainException : Exception
{
    public BaseDomainException()
    {

    }

    public BaseDomainException(string message) : base(message) 
    {

    }
}
