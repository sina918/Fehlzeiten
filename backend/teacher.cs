public class Teacher : Person
{
    public List<string> AtiwClass { get; set; }

    public Teacher(string firstname, string lastname, string email, string login, string password)
        : base(firstname, lastname, email, login, password)
    {
        AtiwClass = new List<string>();
    }
}