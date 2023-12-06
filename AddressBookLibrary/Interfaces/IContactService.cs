namespace AddressBookLibrary.Interfaces;

public interface IContactService
{
    IValidationResult ContactValidation(IContact contact);
    ISearchResult ContactSearch(string email);
}
