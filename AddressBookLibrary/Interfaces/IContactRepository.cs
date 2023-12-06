
namespace AddressBookLibrary.Interfaces;

public interface IContactRepository
{
    IRepositoryResult AddContact(IContact contact);
    IRepositoryResult GetContact(int id);
    IRepositoryResult GetContacts();
    IRepositoryResult DeleteContact(IContact contact);
    IRepositoryResult UpdateContact(IContact contact);
}
