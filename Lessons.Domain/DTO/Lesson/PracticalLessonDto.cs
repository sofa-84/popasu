using Lessons.Domain.DTO.Person;
using Lessons.Domain.Model;

namespace Lessons.Domain.DTO.Lesson;

public class PracticalLessonDto : LessonDto
{
    public PracticalLessonType PracticalLessonType { get; set; }
    public GroupDto Group { get; set; }

    public PracticalLessonDto() : base()
    {
        PracticalLessonType  = PracticalLessonType.Practice;
    }
    public PracticalLessonDto(int id, string name, DateTime dateTime, int classroom, TeacherDto teacher, PracticalLessonType practicalLessonType, GroupDto group) 
        : base(id, name, dateTime, classroom, teacher, LessonType.Practice)
    {
        PracticalLessonType = practicalLessonType;
        Group = group;
    }

    public PracticalLessonDto(PracticalLesson practicalLesson) 
        : this(practicalLesson.Id, practicalLesson.Name, practicalLesson.DateTime, practicalLesson.Classroom, new TeacherDto(practicalLesson.Teacher), practicalLesson.Type, 
            new GroupDto(practicalLesson.Group))
    {
        
    }
}