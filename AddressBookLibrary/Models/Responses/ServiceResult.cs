using AddressBookLibrary.Enums;
using AddressBookLibrary.Interfaces;

namespace AddressBookLibrary.Models.Responses;

public class ServiceResult : IServiceResult
{
    public ServiceStatus Status { get; set; }
    public object Result { get; set; } = null!;
}
