
using AddressBookLibrary.Interfaces;
using AddressBookLibrary.Enums;
using AddressBookConsoleApp.Interfaces;

namespace AddressBookConsoleApp.Services;

public class MenuService : IMenuService
{
    private IContact _contact;
    private IContactRepository _contactRepository;
    private readonly IConsoleService _consoleService;

    public MenuService(IContactRepository contactRepository, IContact contact, IConsoleService consoleService)
    {
        _contactRepository = contactRepository;
        _contact = contact;
        _consoleService = consoleService;
       
    }

    public void ShowMenu()
    {
        _contactRepository.GetAllContactsFromFileToList();

        bool exit = false;

        while (!exit)
        {
            DisplayMainMenu();

            var userInput = _consoleService.ReadLine();

            switch (userInput)
            {
                case "1":
                    AddContact();
                    break;
                case "2":
                    ShowContact();
                    break;
                case "3":
                    DeleteContact();
                    break;
                case "4":
                    ShowAllContacts();
                    break;
                case "0":
                    exit = true;
                    _consoleService.WriteLine("Exiting...");
                    break;
                default:
                    _consoleService.WriteLine("\nInvalid option. Please select a valid option!");
                    _consoleService.ReadKey();
                    break;
            }
        }
    }

    private void DisplayMainMenu()
    {
        DisplayMenuTitle(" Address Book Menu");
        _consoleService.WriteLine("  1.  Add contact");
        _consoleService.WriteLine("  2.  Show contact details");
        _consoleService.WriteLine("  3.  Delete a contact");
        _consoleService.WriteLine("  4.  Show all contacts");
        _consoleService.WriteLine("  0.  Exit");
       
        _consoleService.Write("\nSelect an option ");
    }

    private void DisplayMenuTitle(string title)
    {
        _consoleService.Clear();
        _consoleService.WriteLine("------------------------------------------------------------------------");
        _consoleService.WriteLine(title);
        _consoleService.WriteLine("------------------------------------------------------------------------");
        _consoleService.WriteLine("");
    }

    private void AddContact()
    {
        DisplayMenuTitle($"Add New Contact");

        _consoleService.Write("Enter First Name: ");
        _contact.FirstName = _consoleService.ReadLine() ?? "";
        _consoleService.WriteLine("");

        _consoleService.Write("Enter Last Name: ");
        _contact.LastName = _consoleService.ReadLine() ?? "";
        _consoleService.WriteLine("");

        _consoleService.Write("Enter Email: ");
        _contact.Email = _consoleService.ReadLine() ?? "";
        _consoleService.WriteLine("");

        _consoleService.Write("Enter Phone Number: ");
        _contact.Phone = _consoleService.ReadLine() ?? "";
        _consoleService.WriteLine("");
         
        _consoleService.Write("Enter Address: ");
        _contact.Address = _consoleService.ReadLine() ?? "";
        _consoleService.WriteLine("");

        var result = _contactRepository.AddContact(_contact);
        
        switch (result.Status)
        {
            case RepositoryStatus.Succeeded:
                _consoleService.WriteLine("Contact was successfully added!");
                break;

            case RepositoryStatus.AlreadyExists:
                _consoleService.WriteLine("Contact aready exist!");
                break;

            case RepositoryStatus.Failed:
                _consoleService.WriteLine("Something was wrang!");
                break;
        }

        DisplayPressAnyKey();
    }

    private void ShowContact()
    {
        _consoleService.Write("Enter an Email: ");
        var option = _consoleService.ReadLine() ?? "";
        var result = _contactRepository.GetContact(option);
        
        switch (result.Status)
        {
            case RepositoryStatus.Succeeded:
                if (result.Result is IContact contact)
                {
                    _consoleService.Clear();
                    DisplayContactDetails(contact);
                }
                break;
            case RepositoryStatus.NotFound:
                _consoleService.WriteLine("No contact found for the provided Email.");
                break;
            case RepositoryStatus.Failed:
                _consoleService.WriteLine("An error occurred while fetching the contact details.");
                break;
            default:
                _consoleService.WriteLine("Unexpected status encountered.");
                break;
        }

        DisplayPressAnyKey();

    }

    private void DeleteContact()
    {
        _consoleService.Write("Enter an Email: ");
        var option = _consoleService.ReadLine() ?? "";
        var result = _contactRepository.DeleteContact(option);
        
        switch (result.Status)
        {
            case RepositoryStatus.Succeeded:
                _consoleService.WriteLine("A Contact was successfully deleted!");
                break;
            case RepositoryStatus.NotFound:
                _consoleService.WriteLine("No contact found for the provided Email.");
                break;
            case RepositoryStatus.Failed:
                _consoleService.WriteLine("An error occurred while fetching the contact details.");
                break;
            default:
                _consoleService.WriteLine("Unexpected status encountered.");
                break;
        }
        DisplayPressAnyKey();
    }

    private void ShowAllContacts()  
    {
        DisplayMenuTitle("Show All Contacts");

        var result = _contactRepository.GetAllContacts();
        if (result.Status == RepositoryStatus.Succeeded)
        {
            if (result.Result is List<IContact> contact)
            {
                if (!contact.Any())
                {
                    _consoleService.WriteLine($"There is no any contact in the list.");
                }
                else
                {
                    foreach (var item in contact)
                    {
                        _consoleService.WriteLine($"FirstName: {item.FirstName} LastName: {item.LastName} Email: {item.Email}");
                        _consoleService.WriteLine("");
                    }
                }
            }
        }
        DisplayPressAnyKey();
    }

    private void DisplayContactDetails(IContact contact)            
    {
        DisplayMenuTitle("Detail information of the contact");
        _consoleService.WriteLine($" First Name: {contact.FirstName}");
        _consoleService.WriteLine($" Last Name: {contact.LastName}");
        _consoleService.WriteLine($" Email: {contact.Email}");
        _consoleService.WriteLine($" Phone Number: {contact.Phone}");
        _consoleService.WriteLine($" Address: {contact.Address}");
    }

    private void DisplayPressAnyKey()
    {
        Console.WriteLine();
        _consoleService.WriteLine("Press any key to continue");
        _consoleService.ReadKey();
    }

}
