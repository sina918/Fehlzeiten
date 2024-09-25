public class Student : Person
{
    public string EMailTrainingOrganisation { get; set; }
    public string EMailSepe { get; set; }
    public AbsenceList AbsenceList { get; set; }
    public Teacher Teacher { get; set; }
    public string AtiwClass { get; set; }

    public Student(string firstname, string lastname, string email, string login, string password, 
                   string eMailTrainingOrganisation, string eMailSepe, Teacher teacher, string atiwClass)
                   : base(firstname, lastname, email, login, password)
    {
        EMailTrainingOrganisation = eMailTrainingOrganisation;
        EMailSepe = eMailSepe;
        AbsenceList = null;
        Teacher = teacher;
        AtiwClass = atiwClass;
    }
}