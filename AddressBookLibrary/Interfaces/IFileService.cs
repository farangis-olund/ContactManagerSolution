namespace AddressBookLibrary.Interfaces
{
    public interface IFileService
    {
        IEnumerable<IContact> ReadFromJsonFile (string filePath);
        bool WriteToJsonFile(IEnumerable<IContact> data, string filePath);
    }
}