using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Validators;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
public class DateNotInThePast : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (IsValid(value))
        {
            return ValidationResult.Success;
        }

        return new ValidationResult($"Value {value} is a Date in the past.", [validationContext.MemberName!]);
    }

    public override bool IsValid(object? value)
    {
        if (value is not DateTime)
        {
            return false;
        }

        if (((DateTime) value).ToUniversalTime() < DateTime.UtcNow)
        {
            return false;
        }
        return true;
    }
}
