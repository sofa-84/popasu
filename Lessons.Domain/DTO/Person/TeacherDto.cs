using Lessons.Domain.Model;

namespace Lessons.Domain.DTO.Person;

public class TeacherDto : PersonDto
{
    public string Position { get; set; }

    public TeacherDto() : base()
    {
        
    }
    public TeacherDto(int id, string lastName, string firstName, string? patronymicName, string position) : base(id, lastName, firstName, patronymicName, PersonRole.Teacher)
    {
        Position = position;
    }

    public TeacherDto(Model.Teacher teacher) : this(teacher.Id, teacher.LastName, teacher.FirstName, teacher.PatronymicName, teacher.Position)
    {
    }
}