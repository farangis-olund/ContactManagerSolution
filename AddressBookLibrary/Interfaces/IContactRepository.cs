
namespace AddressBookLibrary.Interfaces;

public interface IContactRepository
{
    IRepositoryResult AddContact(IContact contact);
    IRepositoryResult GetContact(string email);
    IRepositoryResult GetContacts();
    IRepositoryResult DeleteContact(IContact contact);
    IRepositoryResult UpdateContact(IContact contact);
}
