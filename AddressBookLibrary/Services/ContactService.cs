using AddressBookLibrary.Interfaces;
using AddressBookLibrary.Models.Responses;

namespace AddressBookLibrary.Services;

public class ContactService : IContactService
{
    private readonly List<IContact> _contacts = new List<IContact>();
    public IServiceResult AddContact(IContact contact)
    {
        IServiceResult result = new ServiceResult();
        
        try
        {
            if (!_contacts.Any(x => x.Id == contact.Id))
            {
                _contacts.Add(contact);
                result.Status = Enums.ServiceStatus.Suceeded;
            }
            else
            {
                result.Status = Enums.ServiceStatus.AlreadyExists;
            }

        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message);
            result.Status = Enums.ServiceStatus.Failed;
            result.Result = ex.Message;
        }

        return result;

    }

    public IServiceResult DeleteContact(IContact contact)
    {
        throw new NotImplementedException();
    }

    public IServiceResult GetContact(int id)
    {
        throw new NotImplementedException();
    }

    public IServiceResult GetContacts()
    {
        throw new NotImplementedException();
    }

    public IServiceResult UpdateContact(IContact contact)
    {
        throw new NotImplementedException();
    }
}
