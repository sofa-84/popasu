namespace Lessons.Domain.Model;

public class Group
{
    public int Id { get; set; }
    public string Number { get; set; }
    public int Course { get; set; }
    public string Speciality { get; set; }

    public List<Student> Students { get; set; } = new();
    public List<Teacher> Teachers { get; set; } = new();

    public List<PracticalLesson> PracticalLessons { get; set; } = new();
    public List<Lecture> Lectures { get; set; } = new();
}