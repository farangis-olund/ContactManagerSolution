using AddressBookLibrary.Enums;

namespace AddressBookLibrary.Interfaces
{
    public interface IServiceResult
    {
        object Result { get; set; }
        ServiceStatus Status { get; set; }
    }
}