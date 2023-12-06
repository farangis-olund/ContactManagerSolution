using AddressBookLibrary.Enums;
using AddressBookLibrary.Interfaces;

namespace AddressBookLibrary.Models.Responses;

public class RepositoryResult : IRepositoryResult
{
    public RepositoryStatus Status { get; set; }
    public object Result { get; set; } = null!;
}
