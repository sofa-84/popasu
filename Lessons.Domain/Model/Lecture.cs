using System.ComponentModel.DataAnnotations.Schema;

namespace Lessons.Domain.Model;

public enum LectureType
{
    Offline, //Очно
    Online //Дистанционно
}

[Table("Lectures")]
public class Lecture : Lesson
{
    public LectureType Type { get; set; } = LectureType.Offline;
    
    public List<Group> Groups { get; set; } = new();

}