using System.Text.RegularExpressions;
using Group = Lessons.Domain.Model.Group;

namespace Lessons.Domain.DTO;

public class GroupDto
{
    public int Id { get; set; }
    public string Number { get; set; }
    public int Course { get; set; }
    public string Speciality { get; set; }

    public GroupDto()
    {
        
    }
    public GroupDto(int id, string number, int course, string speciality)
    {
        Id = id;
        Number = number;
        Course = course;
        Speciality = speciality;
    }

    public GroupDto(Group group) : this(group.Id, group.Number, group.Course, group.Speciality) {}

}