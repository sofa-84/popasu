using Lessons.Domain.Model;

namespace Lessons.Domain.DTO.Lesson;

public class CreatePracticalLessonDto : CreateLessonDto
{
    public PracticalLessonType PracticalLessonType { get; set; }
    public int GroupId { get; set; }
    
    public CreatePracticalLessonDto() : base()
    {
        PracticalLessonType  = PracticalLessonType.Practice;
    }
    public CreatePracticalLessonDto(string name, DateTime dateTime, int classroom, int teacherId, PracticalLessonType practicalLessonType, int groupId) 
        : base(name, dateTime, classroom, teacherId, LessonType.Practice)
    {
        PracticalLessonType = practicalLessonType;
        GroupId = groupId;
    }

    public CreatePracticalLessonDto(PracticalLesson practicalLesson) 
        : this(practicalLesson.Name, practicalLesson.DateTime, practicalLesson.Classroom, practicalLesson.TeacherId, practicalLesson.Type, practicalLesson.GroupId)
    {
        
    }

}