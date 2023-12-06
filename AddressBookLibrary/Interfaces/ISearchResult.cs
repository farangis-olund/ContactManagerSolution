using AddressBookLibrary.Enums;

namespace AddressBookLibrary.Interfaces
{
    public interface ISearchResult
    {
        object Result { get; set; }
        SearchStatus Status { get; set; }
        int TotalCount { get; set; }
    }
}