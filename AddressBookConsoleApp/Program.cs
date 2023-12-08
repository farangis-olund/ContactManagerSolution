using Microsoft.Extensions.DependencyInjection;
using AddressBookConsoleApp.Services;
using AddressBookConsoleApp.Interfaces;


var serviceProvider = ServiceConfigurator.ConfigureServices();
var menuService = serviceProvider.GetRequiredService<IMenuService>();
menuService.ShowMenu();
