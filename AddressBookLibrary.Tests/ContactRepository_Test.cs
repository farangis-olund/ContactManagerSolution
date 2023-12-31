﻿using AddressBookLibrary.Interfaces;
using AddressBookLibrary.Models;
using AddressBookLibrary.Models.Responses;
using AddressBookLibrary.Repositories;
using Moq;

namespace AddressBookLibrary.Tests;

public class ContactRepository_Test
{
    private ContactRepository contactRepository;
    private Mock<IFileService> _fileServiceMock;
    private IRepositoryResult _repositoryResult;
    private List<IContact> contacts;
    private readonly string filePath = @"C:\projects\contacts.json";
    public ContactRepository_Test()
    {
        // Initializing mock and repository before test
        contacts = new List<IContact>();
        _fileServiceMock = new Mock<IFileService>();
        _repositoryResult= new RepositoryResult();
        contactRepository = new ContactRepository(_fileServiceMock.Object, _repositoryResult);
    }

    [Fact]

    public void AddToList_ShouldAdd_OneContactToContactList_ThenReturnStatusSuceeded()
    {
        //Arrange
        IContact contact = new Contact
        {
            FirstName = "Elsa",
            LastName = "Olund",
            Email = "example@example.com",
            Phone = "07344344",
            Address = "st.Example, 4555"
        };

        //Act
        var result = contactRepository.AddContact(contact);

        //Assert
        Assert.Equal(Enums.RepositoryStatus.Succeeded, result.Status);
        Assert.Single(contacts);
        Assert.Equal(contact.FirstName, contacts[0].FirstName);
    }

    [Fact]
    public void GetContact_WhenExistingEmail_ReturnsContact()
    {
        // Arrange
        IContact contact = new Contact
        {
            FirstName = "Elsa",
            LastName = "Olund",
            Email = "elsa@example.com",
            Phone = "07344344",
            Address = "st.Example, 4555"
        };
        contacts.Add(contact);

        string existingEmail = "elsa@example.com";

        // Act
        var result = contactRepository.GetContact(existingEmail);

        // Assert
        Assert.Equal(Enums.RepositoryStatus.Succeeded, result.Status);
        Assert.NotNull(result.Result);
        Assert.IsType<Contact>(result.Result);
        Assert.Equal(existingEmail, ((Contact)result.Result).Email);
        
    }

    [Fact]
    public void DeleteContact_WhenExistingEmail_DeletesContactSuccessfully()
    {
        // Arrange
        IContact contact = new Contact
        {
            FirstName = "Elsa",
            LastName = "Olund",
            Email = "example@example.com",
            Phone = "07344344",
            Address = "st.Example, 4555"
        };
        contacts.Add(contact);

        // Act
        var result = contactRepository.DeleteContact(contact.Email);

        // Assert
        Assert.Equal(Enums.RepositoryStatus.Succeeded, result.Status);
        Assert.DoesNotContain(contact, contacts); 
                                                          
    }

    [Fact]
    public void DeleteContact_WhenNonExistingEmail_ReturnsNotFoundStatus()
    {
        // Arrange
        var nonExistingEmail = "nonexisting@example.com";

        // Act
        var result = contactRepository.DeleteContact(nonExistingEmail);

        // Assert
        Assert.Equal(Enums.RepositoryStatus.NotFound, result.Status);
        Assert.Null(result.Result); 
                                    
    }

    [Fact]
    public void GetAllContactsToList_ReturnsAllContactsFromFile()
    {
        // Arrange
        var sampleContactsFromFile = new List<IContact>
            {
                new Contact { FirstName = "Elsa", LastName = "Olund", Email = "elsa@example.com", Phone = "07344344", Address = "st.Example, 4555" },
                new Contact { FirstName = "Jane", LastName = "Smith", Email = "jane@example.com", Phone = "54654656", Address = "st.Example, 4555" }
            };

        // Mock behavior of _fileService.ReadFromJsonFile(filePath) to return predefined contacts

        _fileServiceMock.Setup(x => x.ReadFromJsonFile(filePath)).Returns(sampleContactsFromFile);

        var contactRepositoryWithMock = new ContactRepository( _fileServiceMock.Object, _repositoryResult);

        // Act
        var result = contactRepositoryWithMock.GetAllContactsFromFileToList();

        // Assert
        Assert.Equal(Enums.RepositoryStatus.Succeeded, result.Status);
        Assert.NotNull(result.Result);
        Assert.IsType<List<IContact>>(result.Result);
        Assert.Equal(sampleContactsFromFile.Count, ((List<IContact>)result.Result).Count);
        
    }

    [Fact]
    public void GetAllContacts_ReturnsAllContactsSuccessfully()
    {
        // Arrange (no additional arrangement needed)

        // Act
        var result = contactRepository.GetAllContacts();

        // Assert
        Assert.Equal(Enums.RepositoryStatus.Succeeded, result.Status);
        Assert.NotNull(result.Result);
        Assert.Equal(contacts, result.Result); 
    }
}
