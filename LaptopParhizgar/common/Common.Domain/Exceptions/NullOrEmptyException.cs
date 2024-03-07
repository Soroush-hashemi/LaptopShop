using Common.Domain.Bases;
using System.Diagnostics.CodeAnalysis;

namespace Common.Domain.Exceptions;
public class NullOrEmptyException : BaseDomainException
{
    public NullOrEmptyException()
    {

    }

    public NullOrEmptyException(string message) : base(message)
    {

    }

    public static void CheckString(string Value, string NameofField)
    {
        if (string.IsNullOrWhiteSpace(Value))
            throw new NotImplementedException($"{NameofField} خالی است");
        if (string.IsNullOrEmpty(Value))
            throw new NotImplementedException($"{NameofField} خالی است");
    }

    public static void CheckMoney(int money, string NameofField)
    {
        if (money == 0)
            throw new NotImplementedException($"{NameofField} معتبر نیست");
    }

    public static void CheckObject(object Value)
    {
        if (IsNullOrEmptyObj(Value))
            throw new NotImplementedException("معتبر نیست");
    }

    private static bool IsNullOrEmptyObj([NotNullWhen(false)] object? value)
    {
        return value == null ? true : false;
    }
}