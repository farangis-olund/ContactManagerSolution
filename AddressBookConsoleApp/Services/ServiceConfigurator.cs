
using AddressBookConsoleApp.Interfaces;
using AddressBookLibrary.Interfaces;
using AddressBookLibrary.Models.Responses;
using AddressBookLibrary.Models;
using AddressBookLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using AddressBookLibrary.Repositories;

namespace AddressBookConsoleApp.Services;

public class ServiceConfigurator
{
    public static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // Registering Services and its dependencies
        services.AddSingleton<IContactService, ContactService>();
        services.AddSingleton<RepositoryResult>();
        services.AddSingleton<FileService>();
        services.AddSingleton<IContact, Contact>();

        var contactsList = new List<IContact>();
        services.AddSingleton(contactsList);

        services.AddSingleton<IContactRepository>(provider =>
        {
            var contacts = provider.GetRequiredService<List<IContact>>();
            var fileService = provider.GetRequiredService<FileService>();
            var result = provider.GetRequiredService<RepositoryResult>();
            return new ContactRepository(contacts, fileService, result);
        });

        services.AddSingleton<IMenuService, MenuService>(provider =>
        {
            var contactRepository = provider.GetRequiredService<IContactRepository>();
            return new MenuService(contactRepository);
        });

        return services.BuildServiceProvider();
    }
}
