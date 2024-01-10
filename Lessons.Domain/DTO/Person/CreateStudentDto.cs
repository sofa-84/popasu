using Lessons.Domain.Model;

namespace Lessons.Domain.DTO.Person;

public class CreateStudentDto : CreatePersonDto
{
    public int? GroupId { get; set; }

    public CreateStudentDto()
    {
        
    }
    public CreateStudentDto(string lastName, string firstName, string? patronymicName, int? groupId) : base(lastName, firstName, patronymicName, PersonRole.Student)
    {
        GroupId = groupId;
    }

    public CreateStudentDto(Model.Student student) : this(student.LastName, student.FirstName, student.PatronymicName,
        student.GroupId)
    {
        
    }
    
}