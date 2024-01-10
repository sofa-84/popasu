using System.ComponentModel.DataAnnotations.Schema;

namespace Lessons.Domain.Model;

[Table("Teachers")]
public class Teacher : Person
{
    public string Position { get; set; }

    public List<Group> Groups { get; set; } = new();
    
    public List<Lesson> Lessons { get; set; } = new();

}