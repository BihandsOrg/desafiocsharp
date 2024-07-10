namespace Bookstore.Domain.Validation;

public class DomainExceptionValidation : Exception
{
    public DomainExceptionValidation(string error) : base(error)
    { }

    public static void When(bool hasEroor, string error)
    {
        if (hasEroor)
            throw new DomainExceptionValidation(error);
    }
}
