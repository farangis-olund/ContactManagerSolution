
namespace AddressBookLibrary.Interfaces;

public interface IContactRepository
{
    /// <summary>
    /// Add a contact to contact list
    /// </summary>
    /// <param name="contact">a contact a type of IContact</param>
    /// <returns>a repository result a type of IRepositoryResult</returns>
    IRepositoryResult AddContact(IContact contact);


    /// <summary>
    /// Retrieves a contact based on the provided email address from the repository.
    /// </summary>
    /// <param name="email">The email address of the contact to be retrieved.</param>
    /// <returns>
    /// An IRepositoryResult indicating the status of the retrieval operation:
    /// - RepositoryStatus.Succeeded if the contact was successfully found.
    /// - RepositoryStatus.NotFound if the contact with the provided email was not found.
    /// - RepositoryStatus.Failed if an exception occurred during the retrieval process.
    /// </returns>
    IRepositoryResult GetContact(string email);


    /// <summary>
    /// Retrieves all contacts from the repository and returns them as a list.
    /// </summary>
    /// <returns>
    /// An IRepositoryResult indicating the status of the retrieval operation:
    /// - RepositoryStatus.Succeeded if the contacts were successfully retrieved.
    /// - RepositoryStatus.Failed if an exception occurred during the retrieval process.
    /// </returns>
    IRepositoryResult GetAllContactsToList();


    /// <summary>
    /// Retrieves all contacts from the repository.
    /// </summary>
    /// <returns>
    /// An IRepositoryResult indicating the status of the retrieval operation:
    /// - RepositoryStatus.Succeeded if the contacts were successfully retrieved.
    /// - RepositoryStatus.Failed if an exception occurred during the retrieval process.
    /// </returns>
    IRepositoryResult GetAllContacts();


    /// <summary>
    /// Deletes a contact based on the provided email address from the repository.
    /// </summary>
    /// <param name="email">The email address of the contact to be deleted.</param>
    /// <returns>
    /// An IRepositoryResult indicating the status of the delete operation:
    /// - RepositoryStatus.Succeeded if the contact was successfully deleted.
    /// - RepositoryStatus.NotFound if the contact with the provided email was not found.
    /// - RepositoryStatus.Failed if an exception occurred during the deletion process.
    /// </returns>
    IRepositoryResult DeleteContact(string email);


    IRepositoryResult UpdateContact(IContact contact);
}
