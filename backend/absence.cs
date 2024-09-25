using System;

public class Absence
{
    private static int idCounter = 1;

    public int Id { get; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Absenteeism { get; set; }
    public int Confirmed { get; set; }
    public Student Student { get; set; }

    public Absence(DateTime startDate, DateTime endDate, int absenteeism, Student student)
    {
        Id = idCounter++;
        StartDate = startDate;
        EndDate = endDate;
        Absenteeism = absenteeism;
        Confirmed = 0;
        Student = student;
    }
}