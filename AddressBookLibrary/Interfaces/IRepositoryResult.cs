using AddressBookLibrary.Enums;

namespace AddressBookLibrary.Interfaces
{
    public interface IRepositoryResult
    {
        object Result { get; set; }
        RepositoryStatus Status { get; set; }
    }
}