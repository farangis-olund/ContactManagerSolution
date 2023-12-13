using AddressBookConsoleApp.Interfaces;
using AddressBookLibrary.Interfaces;
using AddressBookLibrary.Models.Responses;
using AddressBookLibrary.Models;
using AddressBookLibrary.Services;
using Microsoft.Extensions.DependencyInjection;
using AddressBookLibrary.Repositories;
using Microsoft.Extensions.Hosting;

namespace AddressBookConsoleApp.Services;
public class ServiceConfigurator
{
public static IHostBuilder CreateHostBuilder(string[] args) =>
       Host.CreateDefaultBuilder(args)
           .ConfigureServices((hostContext, services) =>
           {
               // Registering Services and its dependencies
               services.AddSingleton<IRepositoryResult, RepositoryResult>();
               services.AddSingleton<IFileService, FileService>();
               services.AddSingleton<IContact, Contact>();
               services.AddSingleton<IContactRepository, ContactRepository>();
               services.AddSingleton<IMenuService, MenuService>();
               services.AddSingleton<IConsoleService, ConsoleService>();
           });

}
