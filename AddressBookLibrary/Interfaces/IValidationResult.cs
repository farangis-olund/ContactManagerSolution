using AddressBookLibrary.Enums;

namespace AddressBookLibrary.Interfaces
{
    public interface IValidationResult
    {
        ValidationStatus Status { get; set; }
        object ValidationResults { get; set; }
    }
}