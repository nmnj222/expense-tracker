using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Validators;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class IsGreaterThanZeroAttribute : ValidationAttribute
{

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (IsValid(value))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult($"Value {value} is not greater than 0", [validationContext.MemberName!]);
    }

    public override bool IsValid(object? value)
    {
        if (value is not int)
        {
            return false;
        }

        if (!IsGreaterThanZero((int)value))
        {
            return false;
        }
        return true;
    }

    private static bool IsGreaterThanZero(int number)
    {
        return number > 0;
    }
}
