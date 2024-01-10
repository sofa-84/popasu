using Lessons.Domain.Model;

namespace Lessons.Domain.DTO.Person;

public class StudentDto : PersonDto
{
    public int? GroupId { get; set; }
    
    public StudentDto() : base()
    {
        
    }

    public StudentDto(int id, string lastName, string firstName, string? patronymicName, int? groupId) : base(id, lastName, firstName, patronymicName, PersonRole.Student)
    {
        GroupId = groupId;
    }

    public StudentDto(Student student) : this(student.Id, student.LastName, student.FirstName, student.PatronymicName, student.GroupId)
    {
    }
}