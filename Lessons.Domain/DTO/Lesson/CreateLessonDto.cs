using Lessons.Domain.Model;

namespace Lessons.Domain.DTO.Lesson;

public class CreateLessonDto
{
    public string Name { get; set; }
    public DateTime DateTime { get; set; }
    public int Classroom { get; set; }
    private LessonType LessonType { get; set; }

    public int TeacherId { get; set; }
    
    public CreateLessonDto()
    {
        
    }
    public CreateLessonDto(string name, DateTime dateTime, int classroom, int teacherId, LessonType lessonType)
    {
        Name = name;
        DateTime = dateTime;
        Classroom = classroom;
        TeacherId = teacherId;
        LessonType = lessonType;
    }

    public CreateLessonDto(Model.Lesson lesson) : this( lesson.Name, lesson.DateTime, lesson.Classroom, lesson.TeacherId, lesson.LessonType)
    {
        
    }
}