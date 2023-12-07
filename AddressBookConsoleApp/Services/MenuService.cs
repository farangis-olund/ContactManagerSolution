
using AddressBookLibrary.Interfaces;
using AddressBookLibrary.Models;
using AddressBookLibrary.Repositories;
using AddressBookLibrary.Services;

namespace AddressBookConsoleApp.Services;

public interface IMenuService
{
    void ShowMenu();
}

public class MenuService : IMenuService
{
    IContact _contact;
    private IContactRepository _contactRepository;

    public MenuService(IContactRepository contactRepository, IContact contact)
    {
        _contactRepository = contactRepository;
        _contact = contact;
    }

    public void ShowMenu()
    {
       
        while (true)
        {
            DisplayMainMenu();
           
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddContact();
                    break;
                case "2":
                  
                    break;
                case "3":
                    break;
                case "4":
                    break;
                case "0":
                    ExitApp();
                    break;
                default:
                    Console.WriteLine("\nInvalid option selected. Try again!");
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
        Console.WriteLine("  3.  Update a contact");
        Console.WriteLine("  4.  Delete a contact");
        Console.WriteLine("  5.  Show all contacts");
        Console.WriteLine("  0.  Exit");
        Console.WriteLine();
        Console.Write(" SELECT THE OPTION ");

    }

    private void DisplayMenuTitle(string title)
    {
        Console.Clear();
        Console.WriteLine($"   ==== {title} ==== ");
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
            case AddressBookLibrary.Enums.RepositoryStatus.Suceeded:
                Console.WriteLine("A book was added successfully!");
                break;

            case AddressBookLibrary.Enums.RepositoryStatus.AlreadyExists:
                Console.WriteLine("A book aready exist!");
                break;

            case AddressBookLibrary.Enums.RepositoryStatus.Failed:
                Console.WriteLine("Something was wrang!");
                break;
        }

        DisplayPressAnyKey();
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
