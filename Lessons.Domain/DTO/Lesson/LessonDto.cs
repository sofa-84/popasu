using Lessons.Domain.DTO.Person;
using Lessons.Domain.Model;

namespace Lessons.Domain.DTO.Lesson;

public class LessonDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateTime { get; set; }
    public int Classroom { get; set; }
    public LessonType LessonType { get; set; }
    
    public TeacherDto Teacher { get; set; }
    
    public LessonDto()
    {
        
    }
    public LessonDto(int id, string name, DateTime dateTime, int classroom, TeacherDto teacher, LessonType lessonType)
    {
        Id = id;
        Name = name;
        DateTime = dateTime;
        Classroom = classroom;
        Teacher = teacher;
        LessonType = lessonType;
    }

    public LessonDto(Model.Lesson lesson) : this(lesson.Id, lesson.Name, lesson.DateTime, lesson.Classroom, new TeacherDto(lesson.Teacher), lesson.LessonType)
    {
        
    }
    
}