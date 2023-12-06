using AddressBookLibrary.Interfaces;

namespace AddressBookLibrary.Services
{
    public class ContactService : IContactService
    {
        public ISearchResult ContactSearch(string email)
        {
            throw new NotImplementedException();
        }

        public IValidationResult ContactValidation(IContact contact)
        {
            throw new NotImplementedException();
        }
    }
}
