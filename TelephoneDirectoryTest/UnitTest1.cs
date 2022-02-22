using Xunit;
using TELEPHONEDIRECTORY;

namespace TelephoneDirectoryTest;

public class UnitTest1
{
    [Fact]
    public void TestAddContact()
    {
        //Arrange
        var result = new PhoneBook();
        //Act
        result.SizeArray(1);
        result.AddContact(new Contact("andres", "312312", "123123"));
        bool confirm = result.SearchContact("andres");
        //Assert
        Assert.Equal(true, confirm);
    }

    [Fact]
    public void TestAddContactExisting()
    {
        //Arrange
        var result = new PhoneBook();
        //Act
        result.SizeArray(2);
        result.AddContact(new Contact("andres", "312312", "123123"));
        result.AddContact(new Contact("andres", "312312", "123123"));
        byte confirm = result.ListContacts();
        //Assert
        Assert.Equal(1, confirm);
    }

    [Fact]
    public void TestAddContactDirectoryFull()
    {
        //Arrange
        var result = new PhoneBook();
        //Act
        result.SizeArray(1);
        result.AddContact(new Contact("andres", "312312", "123123"));
        result.AddContact(new Contact("carlos", "312312", "123123"));
        byte confirm = result.ListContacts();
        //Assert
        Assert.Equal(1, confirm);
    }

    [Fact]
    public void TestListContact()
    {
        //Arrange
        var result = new PhoneBook();
        //Act
        result.SizeArray(2);
        result.AddContact(new Contact("andres", "312312", "123123"));
        result.AddContact(new Contact("carlos", "312312", "123123"));
        byte confirm = result.ListContacts();
        //Assert
        Assert.Equal(2, confirm);
    }

    [Fact]
    public void TestExistingContact()
    {
        //Arrange
        var result = new PhoneBook();
        //Act
        result.SizeArray(2);
        result.AddContact(new Contact("andres", "312312", "123123"));
        bool confirm = result.ExistingContact(new Contact("andres"));
        //Assert
        Assert.Equal(true, confirm);
    }

    [Fact]
    public void TestDeleteContact()
    {
        //Arrange
        var result = new PhoneBook();
        //Act
        result.SizeArray(2);
        result.AddContact(new Contact("andres", "312312", "123123"));
        bool confirm = result.DeleteContact(new Contact("andres"));
        //Assert
        Assert.Equal(true, confirm);
    }

    [Fact]
    public void TestDeleteContactAndSearchContact()
    {
        //Arrange
        var result = new PhoneBook();
        //Act
        result.SizeArray(2);
        result.AddContact(new Contact("andres", "312312", "123123"));
        result.DeleteContact(new Contact("andres"));
        bool confirm = result.SearchContact("andres");

        //Assert
        Assert.Equal(false, confirm);
    }

    [Fact]
    public void TestDeleteContactAndListContacts()
    {
        //Arrange
        var result = new PhoneBook();
        //Act
        result.SizeArray(3);
        result.AddContact(new Contact("andres", "312312", "123123"));
        result.AddContact(new Contact("carlos", "312312", "123123"));
        result.AddContact(new Contact("vivi", "312312", "123123"));
        result.DeleteContact(new Contact("andres"));
        byte confirm = result.ListContacts();
        //Assert
        Assert.Equal(2, confirm);
    }
    public void TestDeleteContactAndExistingContact()
    {
        //Arrange
        var result = new PhoneBook();
        //Act
        result.SizeArray(1);
        result.AddContact(new Contact("andres", "312312", "123123"));
        result.DeleteContact(new Contact("andres"));
        bool confirm = result.ExistingContact(new Contact("andres"));
        //Assert
        Assert.Equal(false, confirm);
    }

    [Fact]
    public void TestDirectoryFull()
    {
        //Arrange
        var result = new PhoneBook();
        //Act
        result.SizeArray(1);
        result.AddContact(new Contact("andres", "312312", "123123"));
        bool confirm = result.DirectoryFull();
        //Assert
        Assert.Equal(true, confirm);
    }

    [Fact]
    public void TestDirectoryNotFull()
    {
        //Arrange
        var result = new PhoneBook();
        //Act
        result.SizeArray(2);
        result.AddContact(new Contact("andres", "312312", "123123"));
        bool confirm = result.DirectoryFull();
        //Assert
        Assert.Equal(false, confirm);
    }

    [Fact]
    public void TestFreeSpaces()
    {
        //Arrange
        var result = new PhoneBook();
        //Act
        result.SizeArray(2);
        result.AddContact(new Contact("andres", "312312", "123123"));
        bool confirm = result.FreeSpaces();
        //Assert
        Assert.Equal(true, confirm);
    }

    [Fact]
    public void TestFreeSpacesFull()
    {
        //Arrange
        var result = new PhoneBook();
        //Act
        result.SizeArray(2);
        result.AddContact(new Contact("andres", "312312", "123123"));
        result.AddContact(new Contact("carlos", "312312", "123123"));
        bool confirm = result.FreeSpaces();
        //Assert
        Assert.Equal(false, confirm);
    }

    [Fact]
    public void TestSearchContact()
    {
        //Arrange
        var result = new PhoneBook();
        //Act
        result.SizeArray(2);
        result.AddContact(new Contact("andres", "312312", "123123"));
        bool confirm = result.SearchContact("andres");
        //Assert
        Assert.Equal(true, confirm);
    }

    [Fact]
    public void TestSizeArray()
    {
        //Arrange
        var result = new PhoneBook();
        //Act
        byte confirm = result.SizeArray(5);
        //Assert
        Assert.Equal(5, confirm);
    }
}