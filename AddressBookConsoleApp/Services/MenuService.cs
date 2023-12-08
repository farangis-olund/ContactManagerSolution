
using AddressBookLibrary.Interfaces;
using AddressBookLibrary.Enums;
using AddressBookLibrary.Models;

namespace AddressBookConsoleApp.Services;

public interface IMenuService
{
    void ShowMenu();
}

public class MenuService : IMenuService
{
    IContact _contact= new Contact();

    private IContactRepository _contactRepository;

    public MenuService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public void ShowMenu()
    {
        _contactRepository.GetAllContactsToList();
        
        bool exit = false;

        while (!exit)
        {
            DisplayMainMenu();

            var userInput = Console.ReadLine();

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
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("\nInvalid option. Please select a valid option!");
                    Console.ReadKey();
                    break;
            }
        }
    }

    private void DisplayMainMenu()
    {
        DisplayMenuTitle(" Address Book Menu");
        Console.WriteLine("  1.  Add contact");
        Console.WriteLine("  2.  Show a contact");
        Console.WriteLine("  3.  Delete a contact");
        Console.WriteLine("  4.  Show all contacts");
        Console.WriteLine("  0.  Exit");
        Console.WriteLine();
        Console.Write(" Select an option ");
    }

    private void DisplayMenuTitle(string title)
    {
        Console.Clear();
        Console.WriteLine(new string('-', Console.WindowWidth - 1));
        Console.WriteLine(title);
        Console.WriteLine(new string('-', Console.WindowWidth - 1));
        Console.WriteLine();
    }

    private void AddContact()
    {
        DisplayMenuTitle($"Add New Contact");
        
        Console.Write("Enter First Name: ");
        _contact.FirstName = Console.ReadLine() ?? "";
        Console.WriteLine();

        Console.Write("Enter Last Name: ");
        _contact.LastName = Console.ReadLine() ?? "";
        Console.WriteLine();

        Console.Write("Enter Email: ");
        _contact.Email = Console.ReadLine() ?? "";
        Console.WriteLine();

        Console.Write("Enter Phone Number: ");
        _contact.Phone = Console.ReadLine() ?? "";
        Console.WriteLine();

        Console.Write("Enter Address: ");
        _contact.Address = Console.ReadLine() ?? "";
        Console.WriteLine();
        
        var result = _contactRepository.AddContact(_contact);
        
        switch (result.Status)
        {
            case RepositoryStatus.Suceeded:
                Console.WriteLine("Contact was successfully added!");
                break;

            case RepositoryStatus.AlreadyExists:
                Console.WriteLine("Contact aready exist!");
                break;

            case RepositoryStatus.Failed:
                Console.WriteLine("Something was wrang!");
                break;
        }

        DisplayPressAnyKey();
    }

    private void ShowContact()
    {
        Console.Write("Enter an Email: ");
        var option = Console.ReadLine() ?? "";
        var result = _contactRepository.GetContact(option);
        
        switch (result.Status)
        {
            case RepositoryStatus.Suceeded:
                if (result.Result is IContact contact)
                {
                    Console.Clear();
                    DisplayContactDetails(contact);
                }
                break;
            case RepositoryStatus.NotFound:
                Console.WriteLine("No contact found for the provided Email.");
                break;
            case RepositoryStatus.Failed:
                Console.WriteLine("An error occurred while fetching the contact details.");
                break;
            default:
                Console.WriteLine("Unexpected status encountered.");
                break;
        }

        DisplayPressAnyKey();

    }

    private void DeleteContact()
    {
        Console.Write("Enter an Email: ");
        var option = Console.ReadLine() ?? "";
        var result = _contactRepository.DeleteContact(option);
        
        switch (result.Status)
        {
            case RepositoryStatus.Suceeded:
                Console.WriteLine("A Contact was successfully deleted!");
                break;
            case RepositoryStatus.NotFound:
                Console.WriteLine("No contact found for the provided Email.");
                break;
            case RepositoryStatus.Failed:
                Console.WriteLine("An error occurred while fetching the contact details.");
                break;
            default:
                Console.WriteLine("Unexpected status encountered.");
                break;
        }
        DisplayPressAnyKey();
    }

    private void ShowAllContacts()
    {
        DisplayMenuTitle("Show All Contacts");

        var result = _contactRepository.GetAllContacts();
        if (result.Status == RepositoryStatus.Suceeded)
        {
            if (result.Result is List<IContact> contact)
            {
                if (!contact.Any())
                {
                    Console.WriteLine($"There is no any contact in the list.");
                }
                else
                {
                    foreach (var item in contact)
                    {
                        Console.WriteLine($"FirstName: {item.FirstName} LastName: {item.LastName} Email: {item.Email}");
                        Console.WriteLine();
                    }
                }
            }
        }
        DisplayPressAnyKey();
    }

    private void DisplayContactDetails(IContact contact)
    {
        DisplayMenuTitle("Detail information of the contact");
        Console.WriteLine($" First Name: {contact.FirstName}");
        Console.WriteLine($" Last Name: {contact.LastName}");
        Console.WriteLine($" Email: {contact.Email}");
        Console.WriteLine($" Phone Number: {contact.Phone}");
        Console.WriteLine($" Address: {contact.Address}");
    }

    private void DisplayPressAnyKey()
    {
        Console.WriteLine();
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

    private void ExitApp()
    {
        Console.Clear();
        Console.Write("Are you sure that you want to exit? (y/n) ");
        var option = Console.ReadLine() ?? "";
        if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
            Environment.Exit(0);
    }

}
