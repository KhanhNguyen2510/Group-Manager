using static System.Int32;

namespace GM.Data.Validations;

public class MinValueAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
{
    public MinValueAttribute(int min)
    {
        Min = min;
    }

    private int Min { get; }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        TryParse(value.ToString(), out var numValue);
        if (numValue <= Min)
            throw new ApiException(FormatErrorMessage(validationContext.DisplayName), 400);

        return ValidationResult.Success;
    }
}