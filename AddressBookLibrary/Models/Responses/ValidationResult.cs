using AddressBookLibrary.Enums;
using AddressBookLibrary.Interfaces;

namespace AddressBookLibrary.Models.Responses
{
    public class ValidationResult : IValidationResult
    {
        public ValidationStatus Status { get; set; }
        public object ValidationResults { get; set; } = null!;

    }
}
