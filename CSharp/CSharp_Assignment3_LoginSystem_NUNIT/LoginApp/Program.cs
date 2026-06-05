using LoginApp;

Console.WriteLine("----------------------- LOGIN SYSTEM ---------------------------\n");

AuthService auth = new AuthService();

Console.Write("Enter username: ");
string username = Console.ReadLine();

Console.Write("Enter password: ");
string password = Console.ReadLine();

try
{
    bool result = auth.Login(username, password);
    
    if (result)
    {
        Console.WriteLine("\n Login successful! Welcome.");
    }
    else
    {
        Console.WriteLine("\n Login failed! Invalid username or password.");
    }
}
catch (ArgumentException ex)
{
    Console.WriteLine($"\n Error: {ex.Message}");
}