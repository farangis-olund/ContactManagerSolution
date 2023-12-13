using AddressBookLibrary.Interfaces;
using System.Diagnostics;

namespace AddressBookLibrary.Services
{
    public class ContactService : IContactService
    {
        public ISearchResult ContactSearch(string email)
        {
            try
            {

            } catch (Exception ex) { Debug.WriteLine(ex); }
            return null!;
        }

        public IValidationResult ContactValidation(IContact contact)
        {
            try
            {

            }
            catch (Exception ex) { Debug.WriteLine(ex); }
            return null!;
        }
    }
}
