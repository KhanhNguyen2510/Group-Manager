namespace GM.Data.Validations;

public class RequiredAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null ||
            string.IsNullOrEmpty(value.ToString()) ||
            string.IsNullOrWhiteSpace(value.ToString()) ||
            value.ToString()?.Length == 0
           )
        {
            throw new ApiException(FormatErrorMessage(validationContext.DisplayName), 400);
        }

        return ValidationResult.Success;
    }
}