using Lessons.Domain.Model;

namespace Lessons.Domain.DTO.Person;

public class CreateTeacherDto : CreatePersonDto
{
    public string Position { get; set; }

    public CreateTeacherDto() : base()
    {
        
    }
    public CreateTeacherDto(string lastName, string firstName, string? patronymicName, string position) : base(lastName, firstName, patronymicName, PersonRole.Teacher)
    {
        Position = position;
    }

    public CreateTeacherDto(Teacher teacher) : this(teacher.LastName, teacher.FirstName, teacher.PatronymicName, teacher.Position)
    {
    }
}