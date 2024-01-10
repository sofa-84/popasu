namespace Lessons.Domain.Model;
public enum LessonType
{
    Practice, //Практика
    Lecture, //Лекция
    Lab // Лабораторная
}
public class Lesson
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateTime { get; set; }
    public int Classroom { get; set; }
    public LessonType LessonType { get; set; }
    
    public int TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
}