using AddressBookLibrary.Interfaces;
using AddressBookLibrary.Models;
using System.Diagnostics;

namespace AddressBookLibrary.Repositories;

public class ContactRepository(IFileService fileService, IRepositoryResult result) : IContactRepository
{
    private readonly List<IContact> _contacts =[];

    private readonly IFileService _fileService = fileService;
      
    private readonly IRepositoryResult _result = result;

    private readonly string filePath = @"C:\projects\contacts.json";

    public IRepositoryResult AddContact(IContact contact)
    {
        try
        {
            if (!_contacts.Any(x => x.Email == contact.Email))
            {
                var newContact = new Contact
                {
                    FirstName = contact.FirstName,
                    LastName = contact.LastName,
                    Email = contact.Email,
                    Phone = contact.Phone,
                    Address = contact.Address
                    
                };

                _contacts.Add(newContact);
                
                // Save the updated contacts list to a JSON file
                _fileService.WriteToJsonFile(_contacts, filePath);

                _result.Status = Enums.RepositoryStatus.Succeeded;
            }
            else
            {
                _result.Status = Enums.RepositoryStatus.AlreadyExists;
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            _result.Status = Enums.RepositoryStatus.Failed;
            _result.Result = ex.Message;
        }

        return _result;

    }

    public IRepositoryResult DeleteContact(string email)
    {
        try
        {
            var contact = _contacts.FirstOrDefault(x => x.Email == email);
            if (contact != null)
            {
                _contacts.Remove(contact);
                
                _fileService.WriteToJsonFile(_contacts, filePath);

                _result.Status = Enums.RepositoryStatus.Succeeded;
                _result.Result = _contacts; 
            }
            else
            {
                _result.Status = Enums.RepositoryStatus.NotFound;
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            _result.Status = Enums.RepositoryStatus.Failed;
        }
        return _result;
    }

    public IRepositoryResult GetContact(string email)
    {
        try
        {
            var contact = _contacts.FirstOrDefault(x => x.Email == email);
            if (contact != null)
            {
                _result.Status = Enums.RepositoryStatus.Succeeded;
                _result.Result = contact;
            }
            else
            {
                _result.Status = Enums.RepositoryStatus.NotFound;
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        return _result;
    }

    public IRepositoryResult GetAllContactsFromFileToList()
    {
        try
        {
            _contacts.AddRange(_fileService.ReadFromJsonFile(filePath));
            _result.Result = _contacts;
            _result.Status = Enums.RepositoryStatus.Succeeded;

        }
        catch (Exception ex)
        {
            _result.Status = Enums.RepositoryStatus.Failed;
            Debug.WriteLine(ex);
        }
        return _result;
    }

    public IRepositoryResult GetAllContacts()   
    {
        try
        {
            _result.Result = _contacts;
            _result.Status = Enums.RepositoryStatus.Succeeded;

        }
        catch (Exception ex)
        {
            _result.Status = Enums.RepositoryStatus.Failed;
            Debug.WriteLine(ex);
        }
        return _result;
    }

    public IRepositoryResult UpdateContact(IContact contact)
    {
        try
        {


        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        return null!;
    }
}
