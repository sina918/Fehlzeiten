public class Admin : Person
{
    public Admin(string firstname, string lastname, string email, string login, string password)
        : base(firstname, lastname, email, login, password)
    {
        // Additional admin-specific initialization can be added here
    }
}