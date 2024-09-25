public class Person
{
    private static int idCounter = 1;

    public int Id { get; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }

    public Person(string firstname, string lastname, string email, string login, string password)
    {
        Id = idCounter++;
        Firstname = firstname;
        Lastname = lastname;
        Email = email;
        Login = login;
        Password = password;
    }
}