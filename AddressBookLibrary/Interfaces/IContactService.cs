
namespace AddressBookLibrary.Interfaces;

public interface IContactService
{
    IServiceResult AddContact(IContact contact);
    IServiceResult GetContact(int id);
    IServiceResult GetContacts();
    IServiceResult DeleteContact(IContact contact);
    IServiceResult UpdateContact(IContact contact);
}
