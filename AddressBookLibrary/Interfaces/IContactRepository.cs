
namespace AddressBookLibrary.Interfaces;

public interface IContactRepository
{
    IRepositoryResult AddContact(IContact contact);
    IRepositoryResult GetContact(string email);
    IRepositoryResult GetAllContactsToList();
    IRepositoryResult GetAllContacts();
    IRepositoryResult DeleteContact(string email);
    IRepositoryResult UpdateContact(IContact contact);
}
