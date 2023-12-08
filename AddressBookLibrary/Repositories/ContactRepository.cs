using AddressBookLibrary.Interfaces;
using AddressBookLibrary.Models;
using AddressBookLibrary.Models.Responses;
using AddressBookLibrary.Services;
using System.Diagnostics;


namespace AddressBookLibrary.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly List<IContact> _contacts;
    
    private readonly IFileService _fileService;
    
    private readonly string filePath = @"C:\projects\contacts.json";

    IRepositoryResult result= new RepositoryResult();

    public ContactRepository(List<IContact> contacts, IFileService fileService)
    {
        _fileService = fileService;
        _contacts = contacts;
    }


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

                result.Status = Enums.RepositoryStatus.Suceeded;
            }
            else
            {
                result.Status = Enums.RepositoryStatus.AlreadyExists;
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            result.Status = Enums.RepositoryStatus.Failed;
            result.Result = ex.Message;
        }

        return result;

    }

    public IRepositoryResult DeleteContact(string email)
    {
        try
        {
            var contact = _contacts.FirstOrDefault(x => x.Email == email);
            if (contact != null)
            {
                _contacts.Remove(contact);
                // Save the updated contacts list to a JSON file
                _fileService.WriteToJsonFile(_contacts, filePath);

                result.Status = Enums.RepositoryStatus.Suceeded;
                result.Result = _contacts; 
            }
            else
            {
                result.Status = Enums.RepositoryStatus.NotFound;
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            result.Status = Enums.RepositoryStatus.Failed;
        }
        return result;
    }

    public IRepositoryResult GetContact(string email)
    {
        try
        {
            var contact = _contacts.FirstOrDefault(x => x.Email == email);
            if (contact != null)
            {
                result.Status = Enums.RepositoryStatus.Suceeded;
                result.Result = contact;
            }
            else
            {
                result.Status = Enums.RepositoryStatus.NotFound;
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        return result;
    }

    public IRepositoryResult GetAllContactsToList()
    {
        try
        {
            _contacts.AddRange(_fileService.ReadFromJsonFile(filePath));
            result.Result = _contacts;
            result.Status = Enums.RepositoryStatus.Suceeded;

        }
        catch (Exception ex)
        {
            result.Status = Enums.RepositoryStatus.Failed;
            Debug.WriteLine(ex);
        }
        return result;
    }

    public IRepositoryResult GetAllContacts()
    {
        try
        {
            result.Result = _contacts;
            result.Status = Enums.RepositoryStatus.Suceeded;

        }
        catch (Exception ex)
        {
            result.Status = Enums.RepositoryStatus.Failed;
            Debug.WriteLine(ex);
        }
        return result;
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
