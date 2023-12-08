namespace AddressBookLibrary.Interfaces;

public interface IContactService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="contact"></param>
    /// <returns></returns>
    IValidationResult ContactValidation(IContact contact);
    ISearchResult ContactSearch(string email);
}
