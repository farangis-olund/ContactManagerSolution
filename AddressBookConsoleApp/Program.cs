using Microsoft.Extensions.Hosting;
using AddressBookConsoleApp.Services;
using AddressBookLibrary.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using AddressBookLibrary.Repositories;
using AddressBookLibrary.Models;
using AddressBookLibrary.Services;
using AddressBookLibrary.Models.Responses;
using System.Collections.Generic;

var contactsList = new List<IContact>();

var builder = Host.CreateDefaultBuilder().ConfigureServices((services) =>
{
    // Registrating Services and its dependencies

    services.AddSingleton<IContactService, ContactService>();
    services.AddSingleton<IRepositoryResult, RepositoryResult>();
    services.AddSingleton<FileService>();
    services.AddScoped<IContact, Contact>();
    services.AddSingleton<List<IContact>>(contactsList);

    services.AddSingleton<IContactRepository>(provider =>
    {
        var contacts = provider.GetRequiredService<List<IContact>>();
        var fileService = provider.GetRequiredService<FileService>();

        return new ContactRepository(contacts, fileService);
    });
    
    services.AddSingleton<IMenuService, MenuService>(provider =>
    {
        var contactRepository = provider.GetRequiredService<IContactRepository>();
        
        return new MenuService(contactRepository);
    });


}).Build();

// Start the host
builder.Start();
Console.Clear();

var menuService = builder.Services.GetRequiredService<IMenuService>();
menuService.ShowMenu();

