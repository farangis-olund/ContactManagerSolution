using AddressBookLibrary.Interfaces;
using AddressBookLibrary.Models.Responses;
using AddressBookLibrary.Services;
using System.Diagnostics;


namespace AddressBookLibrary.Repositories;

public class ContactRepository : IContactRepository
{
    private  List<IContact> _contacts;
    
    private  FileService _fileService;
    
    private readonly string filePath = @"C:\projects\contacts.json";

    IRepositoryResult result = new RepositoryResult();
    public ContactRepository(List<IContact> contacts, FileService fileService)
    {
        _contacts = contacts ?? new List<IContact>();
        _fileService = fileService;
    }

    public IRepositoryResult AddContact(IContact contact)
    {
        try
        {
            var existingContacts = _fileService.ReadFromJsonFile(filePath).ToList();
            
            _contacts.AddRange(existingContacts);
            
            if (!_contacts.Any(x => x.Email == contact.Email))
            {
                _contacts.Add(contact);
                
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

    public IRepositoryResult DeleteContact(IContact contact)
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

    public IRepositoryResult GetContact(string email)
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

    public IRepositoryResult GetContacts()
    {
        try
        {
            result.Result = _fileService.ReadFromJsonFile(filePath);
            result.Status = Enums.RepositoryStatus.Suceeded;

        }
        catch (Exception ex)
        {
            result.Status = Enums.RepositoryStatus.Failed;
            Debug.WriteLine(ex);
        }
        return null!;
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
