using Common.Domain.Bases;
using Common.Domain.Tools;
using Common.Domain.Exceptions;

namespace Common.Domain.ValueObjects;
public class PhoneNumber : BaseValueObject
{
    public string Value { get; set; }

    public PhoneNumber(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.IsText() || value.Length is < 11 or > 11)
            throw new NullOrEmptyException("شماره تلفن نامعتبر است");
        Value = value;
    }
}