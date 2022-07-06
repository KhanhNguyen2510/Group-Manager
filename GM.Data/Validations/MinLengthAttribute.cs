global using GM.Data.Models;
global using System.ComponentModel.DataAnnotations;

namespace GM.Data.Validations;

public class MinLengthAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
{
    public MinLengthAttribute(int length)
    {
        Length = length;
    }

    private int Length { get; }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value.ToString()?.Length < Length)
            throw new ApiException(FormatErrorMessage(validationContext.DisplayName), 400);

        return ValidationResult.Success;
    }
}