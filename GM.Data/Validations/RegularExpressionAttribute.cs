using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace GM.Data.Validations;

public class RegularExpressionAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
{
    public RegularExpressionAttribute(string pattern)
    {
        Pattern = pattern;
    }

    private string Pattern { get; }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var regex = new Regex(Pattern);
        if (!regex.IsMatch(value.ToString() ?? string.Empty))
            throw new ApiException(FormatErrorMessage(validationContext.DisplayName), 400);

        return ValidationResult.Success;
    }
}

public class RegularExpressionNotNullAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
{
    public RegularExpressionNotNullAttribute(string pattern)
    {
        Pattern = pattern;
    }

    private string Pattern { get; }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var valueString = value.ToString() ?? string.Empty;
        if (string.IsNullOrEmpty(valueString))
            return ValidationResult.Success;
        var regex = new Regex(Pattern);
        if (!regex.IsMatch(valueString))
            throw new ApiException(FormatErrorMessage(validationContext.DisplayName), 400);

        return ValidationResult.Success;
    }
}