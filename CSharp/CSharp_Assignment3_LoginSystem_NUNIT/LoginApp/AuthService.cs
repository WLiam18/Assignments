namespace LoginApp;

public class AuthService
{
    // credentials
    private readonly string _validUsername = "admin";
    private readonly string _validPassword = "password123";

    public bool Login(string username, string password)
    {
        // Check for null or empty
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Username cannot be empty");

        if (string.IsNullOrWhiteSpace(password))
            throw new ArgumentException("Password cannot be empty");

        // Validate credentials
        return username == _validUsername && password == _validPassword;
    }
}