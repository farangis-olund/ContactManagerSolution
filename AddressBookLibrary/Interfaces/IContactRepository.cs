
namespace AddressBookLibrary.Interfaces;

public interface IContactRepository
{
    /// <summary>
    /// Adds a new contact if the email is unique and saves the updated contact list to a JSON file.
    /// </summary>
    /// <param name="contact">The contact to be added to the list.</param>
    /// <returns>
    /// A RepositoryResult object indicating the status of the operation:
    /// - RepositoryStatus.Succeeded if the contact was added successfully.
    /// - RepositoryStatus.AlreadyExists if a contact with the same email already exists.
    /// - RepositoryStatus.Failed if an exception occurred during the operation.
    /// </returns>
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
