namespace Lessons.Domain.Model;


public enum PersonRole
{
    Teacher, //учитель
    Student, //студент
    Supervisor //диспетчер
}
public class Person
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string? PatronymicName { get; set; }
    public PersonRole PersonRole { get; set; }
}