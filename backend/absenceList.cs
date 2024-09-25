using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AbsenceList
{
    private static int idCounter = 1;

    public int Id { get; }
    public Student Student { get; set; }
    public List<Absence> Absences { get; }

    public AbsenceList(){
        Id = idCounter++;
        Student = null;
        Absences = new List<Absence>();
    }

    public AbsenceList(Student student)
    {
        Id = idCounter++;
        Student = student;
        Absences = new List<Absence>();
    }

    // Methods
    public void AddAbsence(Absence newAbsence)
    {
        Absences.Add(newAbsence);
    }

    public void DeleteAbsence(Absence givenAbsence)
    {
        Absences.Remove(givenAbsence);
    }

    // SQL Anfragen

    public void AddAbsenceSql(Absence newAbsence)
    {
        string path = "/C:/Users/a882109/Apps/FehlzeitenDB.db";
        using var connection = new SqliteConnection($"Data Source={path}");
        connection.Open();
        var sql = $"INSERT INTO Absence (id, startDate, endDate, absenteeism, confirmed, student) VALUES ({newAbsence.id}, {newAbsence.startDate}, {newAbsence.endDate}, {newAbsence.absenteeism}, {newAbsence.confirmed}, {newAbsence.student.id})";
        using var command = new SqliteCommand(sql, connection);
        connection.Close();
    }

    public void DeleteAbsenceSql(Absence givenAbsence)
    {
        string path = "/C:/Users/a882109/Apps/FehlzeitenDB.db";
        using var connection = new SqliteConnection($"Data Source={path}");
        connection.Open();
        var sql = $"DELETE FROM Absence WHERE id = {givenAbsence.id};";
        using var command = new SqliteCommand(sql, connection);
        connection.Close();
    }

    public AbsenceList getAbsenceSql(Absence givenAbsence){
        string path = "/C:/Users/a882109/Apps/FehlzeitenDB.db";
        using var connection = new SqliteConnection($"Data Source={path}");
        connection.Open();
        var sql = $"SELECT * FROM Absence WHERE id = {givenAbsence.id};";
        using var command = new SqliteCommand(sql, connection);

        using var reader = command.ExecuteReader();
        AbsenceList results = new AbsenceList();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                results.AddAbsence(new Absence(reader.id, reader.startDate, reader.endDate, reader.absenteeism, reader.confirmed, reader.student));
                
            }
        }
        connection.Close();
        return results;
    }

    public AbsenceList getAbsenceByIdSql(int id){
        string path = "/C:/Users/a882109/Apps/FehlzeitenDB.db";
        using var connection = new SqliteConnection($"Data Source={path}");
        connection.Open();
        var sql = $"SELECT * FROM Absence WHERE id = {id};";
        using var command = new SqliteCommand(sql, connection);

        using var reader = command.ExecuteReader();
        AbsenceList results = new AbsenceList();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                results.AddAbsence(new Absence(reader.id, reader.startDate, reader.endDate, reader.absenteeism, reader.confirmed, reader.student));
                
            }
        }
        connection.Close();
        return results;
    }
    public AbsenceList getAbsenceByStartDateSql(string startDate){
        string formattedDate = startDate.ToString("yyyy-MM-dd");
        string path = "/C:/Users/a882109/Apps/FehlzeitenDB.db";
        using var connection = new SqliteConnection($"Data Source={path}");
        connection.Open();
        var sql = $"SELECT * FROM Absence WHERE startDate = {formattedDate};";
        using var command = new SqliteCommand(sql, connection);

        using var reader = command.ExecuteReader();
        AbsenceList results = new AbsenceList();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                results.AddAbsence(new Absence(reader.id, reader.startDate, reader.endDate, reader.absenteeism, reader.confirmed, reader.student));
                
            }
        }
        connection.Close();
        return results;
    }

}