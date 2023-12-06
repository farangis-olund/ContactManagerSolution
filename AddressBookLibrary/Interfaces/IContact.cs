namespace AddressBookLibrary.Interfaces
{
    public interface IContact
    {
        string City { get; set; }
        string Country { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        int Id { get; set; }
        string LastName { get; set; }
        string Phone { get; set; }
        string State { get; set; }
    }
}