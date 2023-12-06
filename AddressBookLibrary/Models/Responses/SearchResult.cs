using AddressBookLibrary.Enums;
using AddressBookLibrary.Interfaces;

namespace AddressBookLibrary.Models.Responses
{
    public class SearchResult : ISearchResult
    {
        public SearchStatus Status { get; set; }
        public object Result { get; set; } = null!;
        public int TotalCount { get; set; }
    }
}
