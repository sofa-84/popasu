using System.ComponentModel.DataAnnotations.Schema;

namespace Lessons.Domain.Model;

public enum PracticalLessonType
{
    Practice, //Практика
    Lab //Лабораторная
}
[Table("PracticalLessons")]
public class PracticalLesson : Lesson
{
    public PracticalLessonType Type { get; set; } = PracticalLessonType.Practice;
    public int GroupId { get; set; }
    public Group? Group { get; set; }
}