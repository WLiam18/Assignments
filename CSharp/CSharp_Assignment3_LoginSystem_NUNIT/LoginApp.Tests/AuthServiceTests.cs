using NUnit.Framework;
using LoginApp;

namespace LoginApp.Tests;

[TestFixture]
public class AuthServiceTests
{
    private AuthService _auth;

    [SetUp]
    public void Setup()
    {
        _auth = new AuthService();
    }

    //Postive test cases

    [Test]
    public void Login_CorrectCredentials_ReturnsTrue()
    {
        bool result = _auth.Login("admin", "password123");
        Assert.That(result, Is.True);
    }

    [Test]
    public void Login_CorrectUsernameAndPassword_ReturnsTrue()
    {
        bool result = _auth.Login("admin", "password123");
        Assert.That(result, Is.True);
    }

    //Negative test cases 

    [Test]
    public void Login_InvalidUsername_ReturnsFalse()
    {
        bool result = _auth.Login("Liam", "hexa");
        Assert.That(result, Is.False);
    }

    [Test]
    public void Login_InvalidPassword_ReturnsFalse()
    {
        bool result = _auth.Login("admin", "wrongpass");
        Assert.That(result, Is.False);
    }

    [Test]
    public void Login_WrongUsernameAndWrongPassword_ReturnsFalse()
    {
        bool result = _auth.Login("wronguser", "wrongpass");
        Assert.That(result, Is.False);
    }

    [Test]
    public void Login_EmptyUsername_ThrowsException()
    {
        ArgumentException ex = Assert.Throws<ArgumentException>(() => 
            _auth.Login("", "password123"));
        
        Assert.That(ex.Message, Is.EqualTo("Username cannot be empty"));
    }

    [Test]
    public void Login_NullUsername_ThrowsException()
    {
        ArgumentException ex = Assert.Throws<ArgumentException>(() => 
            _auth.Login(null, "password123"));
        
        Assert.That(ex.Message, Is.EqualTo("Username cannot be empty"));
    }

    [Test]
    public void Login_EmptyPassword_ThrowsException()
    {
        ArgumentException ex = Assert.Throws<ArgumentException>(() => 
            _auth.Login("admin", ""));
        
        Assert.That(ex.Message, Is.EqualTo("Password cannot be empty"));
    }

    [Test]
    public void Login_NullPassword_ThrowsException()
    {
        ArgumentException ex = Assert.Throws<ArgumentException>(() => 
            _auth.Login("admin", null));
        
        Assert.That(ex.Message, Is.EqualTo("Password cannot be empty"));
    }

    [Test]
    public void Login_UsernameWithSpaces_ThrowsException()
    {
        ArgumentException ex = Assert.Throws<ArgumentException>(() => 
            _auth.Login("   ", "password123"));
        
        Assert.That(ex.Message, Is.EqualTo("Username cannot be empty"));
    }

    [Test]
    public void Login_CaseSensitive_ReturnsFalse()
    {
        bool result = _auth.Login("ADMIN", "password123");
        Assert.That(result, Is.False);
    }
}