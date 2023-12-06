using AddressBookLibrary.Interfaces;
using AddressBookLibrary.Models.Responses;

namespace AddressBookLibrary.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly List<IContact> _contacts;

    public ContactRepository(List<IContact> contacts)
    {
        _contacts = contacts;
    }

    public IRepositoryResult AddContact(IContact contact)
    {
        IRepositoryResult result = new RepositoryResult();

        try
        {
            if (!_contacts.Any(x => x.Id == contact.Id))
            {
                _contacts.Add(contact);
                result.Status = Enums.RepositoryStatus.Suceeded;
            }
            else
            {
                result.Status = Enums.RepositoryStatus.AlreadyExists;
            }

        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            result.Status = Enums.RepositoryStatus.Failed;
            result.Result = ex.Message;
        }

        return result;

    }

    public IRepositoryResult DeleteContact(IContact contact)
    {
        throw new NotImplementedException();
    }

    public IRepositoryResult GetContact(int id)
    {
        throw new NotImplementedException();
    }

    public IRepositoryResult GetContacts()
    {
        throw new NotImplementedException();
    }

    public IRepositoryResult UpdateContact(IContact contact)
    {
        throw new NotImplementedException();
    }
}
